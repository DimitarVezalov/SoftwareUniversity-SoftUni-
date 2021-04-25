using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.6;
        private const double REFUEL_PERCENTAGE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + FUEL_CONSUMPTION_INCREMENT;

        public override void Refuel(double fuelAmount)
        {
            fuelAmount = fuelAmount * REFUEL_PERCENTAGE;

            base.Refuel(fuelAmount);
        }
    }
}
