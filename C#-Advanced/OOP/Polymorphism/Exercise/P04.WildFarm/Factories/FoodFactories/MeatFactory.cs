using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Factories.FoodFactories
{
    public class MeatFactory : FoodFactory
    {
        public MeatFactory(int quantity)
            : base(quantity)
        {
        }

        public override Food CreateFood()
        {
            return new Meat(this.Quantity);
        }
    }
}
