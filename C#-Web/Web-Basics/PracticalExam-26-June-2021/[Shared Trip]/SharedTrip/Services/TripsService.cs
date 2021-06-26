namespace SharedTrip.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;

    using SharedTrip.Data.Models;
    using SharedTrip.ViewModels.Trips;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddUserToTrip(string userId, string tripId)
        {
            var userTrip = new UserTrip
            {
                UserId = userId,
                TripId = tripId
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public void Create(AddTripInputModel model)
        {

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm",
                    CultureInfo.InvariantCulture),
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            return this.db.Trips
                .Select(t => new TripViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Seats = t.Seats - t.UserTrips.Count
                })
                .ToList();
        }

        public TripDetailsViewModel GetById(string tripId)
        {
            return this.db.Trips
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("s"),
                    Description = t.Description,
                    AvailableSeats = t.Seats - t.UserTrips.Count,
                    ImageUrl = t.ImagePath
                })
                .FirstOrDefault();

        }

        public bool HasSeatsAvailable(string tripId)
        {
            var trip = this.db.Trips
                .Where(t => t.Id == tripId)
                .Select(t => new { Seats = t.Seats, TakenSeats = t.UserTrips.Count })
                .FirstOrDefault();

            var availableSeats = trip.Seats - trip.TakenSeats;

            return availableSeats > 0;
        }

        public bool IsUserInTrip(string userId, string tripId)
        {
            return this.db.UserTrips.Any(ut => ut.UserId == userId && ut.TripId == tripId);
        }
    }
}
