using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity { get => fuelQuantity; private set => fuelQuantity = value; }

        public virtual double FuelConsumption { get => fuelConsumption; private set => fuelConsumption = value; }

        public virtual void Refuel(double fuelAmount)
        {
            this.FuelQuantity += fuelAmount;
        }

        public virtual string Drive(double distance)
        {
            double fuelNeeded = this.FuelConsumption * distance;

            if (this.FuelQuantity >= fuelNeeded)
            {
                this.fuelQuantity -= fuelNeeded;

                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
