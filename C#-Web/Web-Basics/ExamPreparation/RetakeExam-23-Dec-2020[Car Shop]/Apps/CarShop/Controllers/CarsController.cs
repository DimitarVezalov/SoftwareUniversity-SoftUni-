using CarShop.Services;
using CarShop.ViewModels.Cars;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ICarsService carsService;
        private readonly IValidator validator;

        public CarsController(IUsersService usersService, ICarsService carsService, IValidator validator)
        {
            this.usersService = usersService;
            this.carsService = carsService;
            this.validator = validator;
        }


        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (this.usersService.IsUserMechanic(userId))
            {
                var carsNotFixed = this.carsService.GetAllNotFixed();
                return this.View(carsNotFixed);
            }

            var cars = this.carsService.GetAll(userId);

            return this.View(cars);
        }

        public HttpResponse Add()
        {

            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (this.usersService.IsUserMechanic(userId))
            {
                return this.Redirect("/Cars/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCarInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (this.usersService.IsUserMechanic(userId))
            {
                return this.Redirect("/Cars/All");
            }

            var errors = this.validator.ValidateCarInputModel(input);

            if (!String.IsNullOrEmpty(errors))
            {
                return this.Error(errors);
            }

            this.usersService.AddCar(input, userId);

            return this.Redirect("/Cars/All");
        }
    }
}
