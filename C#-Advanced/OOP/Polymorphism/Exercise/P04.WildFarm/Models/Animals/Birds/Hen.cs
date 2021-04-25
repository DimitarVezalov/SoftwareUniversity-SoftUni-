using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double WEIGHT_INCREMENT = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override ICollection<string> PreferedFoods => this.GetPreferedFoods();

        public override double WeightIncrement => WEIGHT_INCREMENT;

        public override string ProduceSound() => "Cluck";

        private string[] GetPreferedFoods()
        {
            string[] preferedFoods =
            {
                "Vegetable",
                "Seeds",
                "Fruit",
                "Meat"
            };

            return preferedFoods;
        }
    }
}
