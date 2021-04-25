using System;
using System.Collections.Generic;
using System.Text;

namespace P02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = (this.FuelConsumption + FUEL_CONSUMPTION_INCREMENT) * distance;

            if (this.FuelQuantity >= fuelNeeded)
            {
                this.FuelQuantity -= fuelNeeded;

                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public string DriveEmpty(double distance)
        {
            return base.Drive(distance);
        }
    }
}
