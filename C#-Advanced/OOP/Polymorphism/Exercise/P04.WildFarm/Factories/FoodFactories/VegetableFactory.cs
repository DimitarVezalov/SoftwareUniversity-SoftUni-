using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Factories.FoodFactories
{
    public class VegetableFactory : FoodFactory
    {
        public VegetableFactory(int quantity)
            : base(quantity)
        {
        }

        public override Food CreateFood()
        {
            return new Vegetable(this.Quantity);
        }
    }
}
