using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals.Mammals
{
    public class Tiger : Feline
    {
        private const double WEIGHT_INCREMENT = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound() => "ROAR!!!";

        public override ICollection<string> PreferedFoods => this.GetPreferedFoods();

        public override double WeightIncrement => WEIGHT_INCREMENT;

        private string[] GetPreferedFoods()
        {
            string[] preferedFoods =
            {
                "Meat"
            };

            return preferedFoods;
        }
    }
}
