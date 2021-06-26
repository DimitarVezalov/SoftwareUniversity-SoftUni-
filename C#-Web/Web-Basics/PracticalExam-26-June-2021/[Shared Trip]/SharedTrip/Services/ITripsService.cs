using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
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
