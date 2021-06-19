using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Car CreateCar(string model, int year, string imageUrl, string plateNumber)
        {
            var car = new Car
            {
                Model = model,
                Year = year,
                PictureUrl = imageUrl,
                PlateNumber = plateNumber
            };

            return car;
        }

        public ICollection<CarAllViewModel> GetAll(string userId)
        {
            var cars = this.db.Cars
                .Where(c => c.OwnerId == userId)
                .Select(c => new CarAllViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    PlateNumber = c.PlateNumber,
                    ImageUrl = c.PictureUrl,
                    RemainingIssues = c.Issues.Count(x => !x.IsFixed),
                    FixedIssues = c.Issues.Count(x => x.IsFixed)
                })
                .ToList();

            return cars;
        }

        public ICollection<CarAllViewModel> GetAllNotFixed()
        {
            var carsNotFixed = this.db.Cars
                .Where(c => c.Issues.Any(i => i.IsFixed == false))
                .Select(c => new CarAllViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    PlateNumber = c.PlateNumber,
                    ImageUrl = c.PictureUrl,
                    FixedIssues = c.Issues.Count(i => i.IsFixed),
                    RemainingIssues = c.Issues.Count(i => !i.IsFixed),
                })
                .ToList();

            return carsNotFixed;
        }
    }
}
