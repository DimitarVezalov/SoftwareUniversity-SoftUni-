namespace SharedTrip.Services
{
    using System.Collections.Generic;

    using SharedTrip.ViewModels.Trips;

    public interface ITripsService
    {
        void Create(AddTripInputModel model);

        IEnumerable<TripViewModel> GetAll();

        TripDetailsViewModel GetById(string tripId);

        void AddUserToTrip(string userId, string tripId);

        bool HasSeatsAvailable(string tripId);

        bool IsUserInTrip(string userId, string tripId);
    }
}
