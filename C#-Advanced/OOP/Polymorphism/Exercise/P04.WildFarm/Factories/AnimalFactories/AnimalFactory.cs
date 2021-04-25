using P04.WildFarm.Models.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Factories.AnimalFactories
{
    public abstract class AnimalFactory
    {
        public AnimalFactory(string[] animalArgs)
        {
            this.Name = animalArgs[1];
            this.Weigh = double.Parse(animalArgs[2]);
        }

        public string Name { get; }

        public double Weigh { get; }

        public abstract Animal CreateAnimal();
    }
}
