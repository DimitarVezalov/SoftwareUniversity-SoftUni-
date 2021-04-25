using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MIN_NAME_LENGTH = 5;
        private const int MIN_LAPS_COUNT = 1;

        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
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

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < MIN_LAPS_COUNT)
                {
                    string excMessage = String.Format(ExceptionMessages.InvalidNumberOfLaps, MIN_LAPS_COUNT);
                    throw new ArgumentException(excMessage);
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                string excMessage = String.Format(ExceptionMessages.DriverNotParticipate, driver.Name);
                throw new ArgumentException(excMessage);
            }

            //WRONG EXCEPTION??
            if (this.Drivers.Any(d => d.Name == driver.Name))
            {
                string excMessage = String.Format(ExceptionMessages.DriverAlreadyAdded,
                    driver.Name, this.name);

                throw new ArgumentNullException(excMessage);
            }

            this.drivers.Add(driver);
        }
    }
}
