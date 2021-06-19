using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;
using Microsoft.EntityFrameworkCore;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesService issuesService;
        private readonly IUsersService usersService;
        private readonly IValidator validator;
        private readonly ApplicationDbContext db;

        public IssuesController(IIssuesService issuesService, IUsersService usersService, IValidator validator, ApplicationDbContext db)
        {
            this.issuesService = issuesService;
            this.usersService = usersService;
            this.validator = validator;
            this.db = db;
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var carWithIssues = this.issuesService.GetCarIssuesByCarId(carId);   

            return this.View(carWithIssues);
        }
        
        
        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View(carId);
        }

        [HttpPost]
        public HttpResponse Add(AddIssueInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.issuesService.CreateIssue(input.Description, input.CarId);

            return this.Redirect($"/Issues/CarIssues?carId={input.CarId}");
        }

        public HttpResponse Fix(string issueId, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.usersService.IsUserMechanic(this.GetUserId()))
            {
                return this.Error("You are not alowed to fix issues!");
            }

            this.issuesService.FixIssue(issueId, carId);

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }

        public HttpResponse Delete(string issueId, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.issuesService.DeleteIssue(issueId, carId);

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
