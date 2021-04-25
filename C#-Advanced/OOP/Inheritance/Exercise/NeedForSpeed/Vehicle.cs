using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;

        private int horsePower;
        private double fuel;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get => this.horsePower; set => this.horsePower = value; }
        public double Fuel { get => this.fuel; set => this.fuel = value; }

        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
        
        public virtual void Drive(double kilometers)
        {
            this.Fuel -= (this.FuelConsumption * kilometers);
        }
    }
}
