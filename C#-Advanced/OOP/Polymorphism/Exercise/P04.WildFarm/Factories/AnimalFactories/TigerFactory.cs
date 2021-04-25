using P04.WildFarm.Models.Animals;
using P04.WildFarm.Models.Animals.Mammals;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Factories.AnimalFactories
{
    public class TigerFactory : AnimalFactory
    {
        public TigerFactory(string[] animalArgs)
         : base(animalArgs)
        {
            this.LivingRegion = animalArgs[3];
            this.Breed = animalArgs[4];
        }

        public string LivingRegion { get; }

        public string Breed { get; }

        public override Animal CreateAnimal()
        {
            return new Tiger(this.Name, this.Weigh, this.LivingRegion, this.Breed);
        }
    }
}
