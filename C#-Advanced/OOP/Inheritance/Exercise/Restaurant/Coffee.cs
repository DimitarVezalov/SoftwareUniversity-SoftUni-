using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double DEFAULT_MILLILITERS = 50;
        private const decimal DEFAULT_PRICE = 3.50m;

        private double caffeine;

        public Coffee(string name, double caffeine)
            : base(name, DEFAULT_PRICE, DEFAULT_MILLILITERS)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get => this.caffeine; set => this.caffeine = value; }
    }
}
