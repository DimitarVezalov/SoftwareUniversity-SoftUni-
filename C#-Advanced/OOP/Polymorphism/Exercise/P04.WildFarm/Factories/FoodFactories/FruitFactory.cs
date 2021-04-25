using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Factories.FoodFactories
{
    public class FruitFactory : FoodFactory
    {
        public FruitFactory(int quantity)
            : base(quantity)
        {
        }

        public override Food CreateFood()
        {
            return new Fruit(this.Quantity);
        }
    }
}
