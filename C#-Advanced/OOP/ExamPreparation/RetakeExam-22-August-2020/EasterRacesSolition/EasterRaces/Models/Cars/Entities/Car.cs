using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MIN_MODEL_LENGTH = 4;

        private string model;
        private int horsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;  
        }


        public string Model 
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    string excMessage = String.Format(ExceptionMessages.InvalidModel, value, MIN_MODEL_LENGTH); 
                    throw new ArgumentException(excMessage);
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value < this.MinHorsePower || value > this.MaxHorsePower)
                {
                    string excMessage = String.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(excMessage);
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; }


        public int MinHorsePower { get; }
 

        public int MaxHorsePower { get; }


        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
