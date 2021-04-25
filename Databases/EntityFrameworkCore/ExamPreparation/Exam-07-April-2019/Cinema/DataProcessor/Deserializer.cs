namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var movieDtos = JsonConvert.DeserializeObject<MovieInputModel[]>(jsonString);

            List<Movie> validMovies = new List<Movie>();

            foreach (var dto in movieDtos)
            {
                if (dto.Title.Length < 3 || dto.Title.Length > 20)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre;
                bool isGenreParsed = Enum.TryParse<Genre>(dto.Genre, out genre);

                if (!isGenreParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Movie movie = new Movie
                {
                    Title = dto.Title,
                    Genre = genre
                };

                TimeSpan duration;
                bool isDurationParsed = TimeSpan.TryParse(dto.Duration, out duration);

                if (!isDurationParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                movie.Duration = duration;

                if (dto.Rating < 1 || dto.Rating > 10)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                movie.Rating = dto.Rating;

                if (dto.Director.Length < 3 || dto.Director.Length > 20)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                movie.Director = dto.Director;

                validMovies.Add(movie);
                sb.AppendLine(String.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var hallSeatsDtos = JsonConvert.DeserializeObject<HallAndSeatsInputModel[]>(jsonString);

            foreach (var dto in hallSeatsDtos)
            {
                if (dto.Name.Length < 3 || dto.Name.Length > 20 || dto.Seats <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Hall hall = new Hall
                {
                    Name = dto.Name,
                    Is4Dx = dto.Is4Dx,
                    Is3D = dto.Is3D
                };

                for (int i = 1; i <= dto.Seats; i++)
                {
                    Seat seat = new Seat
                    {
                        Hall = hall
                    };

                    hall.Seats.Add(seat);
                }

                context.Halls.Add(hall);

                string projectionString = "";

                if (dto.Is4Dx && dto.Is3D)
                {
                    projectionString = "4Dx/3D";
                }
                else if (dto.Is4Dx && !dto.Is3D)
                {
                    projectionString = "4Dx";
                }
                else if (!dto.Is4Dx && dto.Is3D)
                {
                    projectionString = "3D";
                }
                else
                {
                    projectionString = "Normal";
                }


                sb.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, projectionString, dto.Seats));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = 
                new XmlSerializer(typeof(ProjectionInputModel[]), new XmlRootAttribute("Projections"));

            ProjectionInputModel[] projectionDtos;

            using (var reader = new StringReader(xmlString))
            {
                projectionDtos = (ProjectionInputModel[])serializer.Deserialize(reader);
            }

            foreach (var dto in projectionDtos)
            {
                if (!context.Movies.Select(m => m.Id).Contains(dto.MovieId) || 
                    !context.Halls.Select(h => h.Id).Contains(dto.HallId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime dtoDateTime = DateTime.ParseExact(dto.DateTime, "yyyy-MM-dd HH:mm:ss",
                       CultureInfo.InvariantCulture);

                Projection projection = new Projection
                {
                    MovieId = dto.MovieId,
                    HallId = dto.HallId,
                    DateTime = dtoDateTime.Date
                };

                context.Projections.Add(projection);
                sb.AppendLine(String.Format
                    (SuccessfulImportProjection, projection.Movie.Title, 
                    projection.DateTime.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) ));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = 
                new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));

            CustomerInputModel[] customerDtos;

            using (var reader = new StringReader(xmlString))
            {
                customerDtos = (CustomerInputModel[])serializer.Deserialize(reader);
            }

            foreach (var dto in customerDtos)
            {
                if ((dto.FirstName.Length < 3 || dto.FirstName.Length > 20)||
                    dto.LastName.Length < 3 || dto.LastName.Length > 20)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dto.Age < 12 || dto.Age > 110)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dto.Balance < 0.01m)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer customer = new Customer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance
                };

                foreach (var ticketDto in dto.Tickets)
                {
                    if (ticketDto.Price < 0.01m)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket
                    {
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price                        
                    };

                    customer.Tickets.Add(ticket);
                }

                context.Customers.Add(customer);

                sb.AppendLine(String.Format(SuccessfulImportCustomerTicket, customer.FirstName, 
                    customer.LastName, customer.Tickets.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
    }
}