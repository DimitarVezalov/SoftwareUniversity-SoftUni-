namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count > 0))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("F2"),
                    TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = m.Projections.SelectMany(p => p.Tickets).Select(t => new
                    {
                        FirstName = t.Customer.FirstName,
                        LastName = t.Customer.LastName,
                        Balance = t.Customer.Balance.ToString("F2")
                    })
                    .OrderByDescending(x => x.Balance)
                    .ThenBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToArray()
                })
                .Take(10)
                .ToList();

            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return json;

        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            StringBuilder sb = new StringBuilder();

            var customers = context.Customers
                .Where(c => c.Age >= age)
                .Select(c => new CustomerExportModel
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = decimal.Parse(c.Tickets.Sum(t => t.Price).ToString("f2")),
                    SpentTime = new TimeSpan(c.Tickets.Select(t => t.Projection.Movie.Duration)
                                            .Sum(x => x.Ticks)).ToString("hh\\:mm\\:ss")
                })         
                .OrderByDescending(x => x.SpentMoney)
                .Take(10)
                .ToArray();

            XmlSerializer serializer =
                new XmlSerializer(typeof(CustomerExportModel[]), new XmlRootAttribute("Customers"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}