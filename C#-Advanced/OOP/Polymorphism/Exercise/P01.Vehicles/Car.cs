using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles
{
    class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + FUEL_CONSUMPTION_INCREMENT;
    }
}
