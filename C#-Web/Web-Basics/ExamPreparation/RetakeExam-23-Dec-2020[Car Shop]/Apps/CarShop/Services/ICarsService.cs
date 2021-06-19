using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public interface ICarsService
    {
        Car CreateCar(string model, int year, string imageUrl, string plateNumber);

        ICollection<CarAllViewModel> GetAll(string userId);

        ICollection<CarAllViewModel> GetAllNotFixed();
    }
}
