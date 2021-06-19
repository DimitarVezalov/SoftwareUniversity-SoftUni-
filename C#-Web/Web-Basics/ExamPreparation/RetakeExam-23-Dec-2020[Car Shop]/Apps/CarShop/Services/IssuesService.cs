using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateIssue(string description, string carId)
        {
            var issue = new Issue
            {
                CarId = carId,
                Description = description,
                IsFixed = false
            };

            this.db.Issues.Add(issue);
            this.db.SaveChanges();
        }

        public void DeleteIssue(string issueId, string carId)
        {
            var issue = this.db.Issues
                 .FirstOrDefault(i => i.Id == issueId && i.CarId == carId);

            this.db.Remove(issue);
            this.db.SaveChanges();
        }

        public void FixIssue(string issueId, string carId)
        {
            var issue = this.db.Issues
                .FirstOrDefault(i => i.Id == issueId && i.CarId == carId);

            issue.IsFixed = true;

            this.db.Update(issue);
            this.db.SaveChanges();
        }

        public CarWithIssuesViewModel GetCarIssuesByCarId(string carId)
        {
            var car = this.db.Cars
                .Include(c => c.Issues)
                .FirstOrDefault(c => c.Id == carId);

            var carWithIssues = new CarWithIssuesViewModel
            {
                Id = car.Id,
                Model = car.Model,
                Year = car.Year,
                Issues = car.Issues.Select(i => new IssueListViewModel
                {
                    Id = i.Id,
                    Description = i.Description,
                    IsFixed = i.IsFixed
                })
                .ToList()
            };

            return carWithIssues;
        }
    }
}
