using CarShop.Services;
using CarShop.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IValidator validator;

        public UsersController(IUsersService usersService, IValidator validator)
        {
            this.usersService = usersService;
            this.validator = validator;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cars/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cars/All");
            }

            var userId = this.usersService.GetUserId(model.Username, model.Password);

            if (userId == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(userId);

            return this.Redirect("/Cars/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cars/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cars/All");
            }

            string errors = validator.ValidateUserRegistrationModel(model);

            if (!String.IsNullOrEmpty(errors))
            {
                return this.Error(errors);
            }

            this.usersService.Create(model.Username, model.Email, model.Password, model.UserType);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/USers/Login");
            }

            this.SignOut();

            return this.Redirect("/");
        }
    }
}
