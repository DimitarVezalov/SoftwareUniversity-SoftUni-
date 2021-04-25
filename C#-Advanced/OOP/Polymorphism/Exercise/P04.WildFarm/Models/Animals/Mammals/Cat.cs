using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals.Mammals
{
    public class Cat : Feline
    {
        private const double WEIGHT_INCREMENT = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override ICollection<string> PreferedFoods => this.GetPreferedFoods();

        public override double WeightIncrement => WEIGHT_INCREMENT;

        public override string ProduceSound() => "Meow";

        private string[] GetPreferedFoods()
        {
            string[] preferedFoods =
            {
                "Vegetable",
                "Meat"
            };

            return preferedFoods;
        }

    }
}
