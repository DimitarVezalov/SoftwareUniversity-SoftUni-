using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Factories.FoodFactories
{
    public abstract class FoodFactory
    {
        public FoodFactory(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; }

        public abstract Food CreateFood();
    }
}
