using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;
        private readonly IValidator validator;

        public TripsController(ITripsService tripsService, IValidator validator)
        {
            this.tripsService = tripsService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.tripsService.GetAll();

            return this.View(trips);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddTripInputModel input)
        {
            if (!this.validator.ValidateAddTrip(input))
            {
                return this.Redirect("/Trips/Add");
            }

            this.tripsService.Create(input);

            return this.All();
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.tripsService.GetById(tripId);

            return this.View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (this.tripsService.IsUserInTrip(this.User.Id, tripId) || !this.tripsService.HasSeatsAvailable(tripId))
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            this.tripsService.AddUserToTrip(this.User.Id, tripId);

            return this.Redirect("/Trips/All");
        }
    }
}
