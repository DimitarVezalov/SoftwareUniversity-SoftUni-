using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MIN_NAME_LENGTH = 5;

        private string name;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < MIN_NAME_LENGTH)
                {
                    string excMessage = String.Format(ExceptionMessages.InvalidName, value, MIN_NAME_LENGTH);
                    throw new ArgumentException(excMessage);
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins  { get; private set; }

        public bool CanParticipate => this.Car != null;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                string excMessage = String.Format(ExceptionMessages.CarInvalid);
                throw new ArgumentNullException(excMessage);
            }

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
