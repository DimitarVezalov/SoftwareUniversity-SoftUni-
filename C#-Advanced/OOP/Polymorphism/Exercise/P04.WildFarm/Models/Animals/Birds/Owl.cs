using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double WEIGHT_INCREMENT = 0.25;

        public Owl(string name,double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override ICollection<string> PreferedFoods => this.GetPreferedFoods();

        public override double WeightIncrement => WEIGHT_INCREMENT;

        public override string ProduceSound() => "Hoot Hoot";

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
