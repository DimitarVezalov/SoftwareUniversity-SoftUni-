using P04.WildFarm.Factories;
using P04.WildFarm.Factories.AnimalFactories;
using P04.WildFarm.Factories.FoodFactories;
using P04.WildFarm.Models.Animals;
using P04.WildFarm.Models.Animals.Birds;
using P04.WildFarm.Models.Animals.Mammals;
using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.WildFarm
{
    public class Engine
    {
        public object AnimaFactory { get; private set; }

        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] animalArgs = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string animalType = animalArgs[0];

                AnimalFactory animalFactory = null;

                switch (animalType)
                {
                    case "Cat":
                        animalFactory = new CatFactory(animalArgs);
                        break;
                    case "Tiger":
                        animalFactory = new TigerFactory(animalArgs);
                        break;
                    case "Owl":
                        animalFactory = new OwlFactory(animalArgs);
                        break;
                    case "Hen":
                        animalFactory = new HenFactory(animalArgs);
                        break;
                    case "Dog":
                        animalFactory = new DogFactory(animalArgs);
                        break;
                    case "Mouse":
                        animalFactory = new MouseFactory(animalArgs);
                        break;
                }

                Animal animal = animalFactory.CreateAnimal();

                Console.WriteLine(animal.ProduceSound());
                animals.Add(animal);

                string[] foodArgs = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                string foodType = foodArgs[0];
                int quantity = int.Parse(foodArgs[1]);

                FoodFactory foodFactory = null;

                if (foodType == "Fruit")
                {
                    foodFactory = new FruitFactory(quantity);
                }
                else if (foodType == "Meat")
                {
                    foodFactory = new MeatFactory(quantity);
                }
                else if (foodType == "Seeds")
                {
                    foodFactory = new SeedsFactory(quantity);
                }
                else if (foodType == "Vegetable")
                {
                    foodFactory = new VegetableFactory(quantity);
                }

                Food food = foodFactory.CreateFood();

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
