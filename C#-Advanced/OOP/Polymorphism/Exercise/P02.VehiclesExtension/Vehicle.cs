using System;
using System.Collections.Generic;
using System.Text;

namespace P02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set => this.fuelQuantity = value;
        }

        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            protected set => fuelConsumption = value;
        }
        public double TankCapacity
        { 
            get => tankCapacity;
            set => tankCapacity = value;
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount + this.FuelQuantity >= this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }

            if (fuelAmount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

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
