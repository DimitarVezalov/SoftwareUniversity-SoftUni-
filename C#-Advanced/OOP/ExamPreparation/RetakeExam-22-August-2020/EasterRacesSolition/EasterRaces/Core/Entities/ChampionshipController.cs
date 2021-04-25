using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly List<IDriver> drivers;
        private readonly List<ICar> cars;
        private readonly List<IRace> races;

        public ChampionshipController()
        {
            this.drivers = new List<IDriver>();
            this.cars = new List<ICar>();
            this.races = new List<IRace>();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!this.drivers.Any(d => d.Name == driverName))
            {
                string excMessageDriver = String.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(excMessageDriver);
            }

            if (!this.cars.Any(c => c.Model == carModel))
            {
                string excMessageCar = String.Format(ExceptionMessages.CarNotFound, carModel);
                throw new InvalidOperationException(excMessageCar);
            }

            IDriver driver = this.drivers.FirstOrDefault(d => d.Name == driverName);
            ICar car = this.cars.FirstOrDefault(c => c.Model == carModel);

            driver.AddCar(car);

            string output = String.Format(OutputMessages.CarAdded, driverName, carModel);

            return output;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!this.races.Any(r => r.Name == raceName))
            {
                string excMessage = String.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(excMessage);
            }

            if (!this.drivers.Any(r => r.Name == driverName))
            {
                string excMessage = String.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(excMessage);
            }

            IRace race = this.races.FirstOrDefault(r => r.Name == raceName);
            IDriver driver = this.drivers.FirstOrDefault(d => d.Name == driverName);

            race.AddDriver(driver);

            string output = String.Format(OutputMessages.DriverAdded, driverName, raceName);

            return output;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.Any(c => c.Model == model))
            {
                string excMessage = String.Format(ExceptionMessages.CarExists, model);
                throw new ArgumentException(excMessage);
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.cars.Add(car);

            string output = String.Format(OutputMessages.CarCreated, car.GetType().Name, model);

            return output;
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.Any(d => d.Name == driverName))
            {
                string excMessage = String.Format(ExceptionMessages.DriversExists, driverName);
                throw new ArgumentException(excMessage);
            }

            IDriver driver = new Driver(driverName);
            this.drivers.Add(driver);

            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.Any(r => r.Name == name))
            {
                string excMessage = String.Format(ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(excMessage);
            }

            IRace race = new Race(name, laps);
            this.races.Add(race);

            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (!this.races.Any(r => r.Name == raceName))
            {
                string excMessage = String.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(excMessage);
            }

            IRace race = this.races.FirstOrDefault(r => r.Name == raceName);

            if (race.Drivers.Count < 3)
            {
                string excMessage = String.Format(ExceptionMessages.RaceInvalid, raceName, 3);
                throw new InvalidOperationException(excMessage);
            }

            List<IDriver> drivers = race
                .Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            IDriver first = drivers[0];
            IDriver second = drivers[1];
            IDriver third = drivers[2];

            races.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(String.Format(OutputMessages.DriverFirstPosition, first.Name, race.Name))
                .AppendLine(String.Format(OutputMessages.DriverSecondPosition, second.Name, race.Name))
                .AppendLine(String.Format(OutputMessages.DriverThirdPosition, third.Name, race.Name));

            return sb.ToString().TrimEnd();
        }
    }
}
