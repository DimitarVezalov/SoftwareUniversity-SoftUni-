using P04.WildFarm.Models.Animals;
using P04.WildFarm.Models.Animals.Birds;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Factories.AnimalFactories
{
    public class OwlFactory : AnimalFactory
    {
        public OwlFactory(string[] animalArgs)
             : base(animalArgs)
        {
            this.WingSize = double.Parse(animalArgs[3]);
        }

        public double WingSize { get; set; }

        public override Animal CreateAnimal()
        {
            return new Owl(this.Name, this.Weigh, this.WingSize);
        }
    }
}
