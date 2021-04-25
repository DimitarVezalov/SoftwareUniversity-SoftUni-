using System;
using System.Collections.Generic;
using System.Text;

namespace P02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.6;
        private const double REFUEL_PERCENTAGE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + FUEL_CONSUMPTION_INCREMENT;

        public override void Refuel(double fuelAmount)
        {
            double newFuelAmount = fuelAmount * REFUEL_PERCENTAGE;

            if (newFuelAmount + this.FuelQuantity >= this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }

            if (newFuelAmount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            this.FuelQuantity += newFuelAmount;
        }
    }
}
