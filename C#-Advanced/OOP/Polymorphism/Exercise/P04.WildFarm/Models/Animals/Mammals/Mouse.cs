using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double WEIGHT_INCREMENT = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override ICollection<string> PreferedFoods => this.GetPreferedFoods();

        public override double WeightIncrement => WEIGHT_INCREMENT;

        public override string ProduceSound() => "Squeak";

        private string[] GetPreferedFoods()
        {
            string[] preferedFoods =
            {
                "Vegetable",
                "Fruit",
            };

            return preferedFoods;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}," +
                                        $" {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
