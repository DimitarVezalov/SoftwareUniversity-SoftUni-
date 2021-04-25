using P04.WildFarm.Models.Animals;
using P04.WildFarm.Models.Animals.Mammals;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Factories.AnimalFactories
{
    public class DogFactory : AnimalFactory
    {
        public DogFactory(string[] animalArgs)
            : base(animalArgs)
        {
            this.LivingRegion = animalArgs[3];
        }

        public string LivingRegion { get; }

        public override Animal CreateAnimal()
        {
            return new Dog(this.Name, this.Weigh, this.LivingRegion);
        }
    }
}
