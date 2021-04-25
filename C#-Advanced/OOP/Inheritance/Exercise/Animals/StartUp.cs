using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            
            while (true)
            {
                string animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }

                string[] animalArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    Animal animal = AnimalFactory.CreateAnimal(animalType, animalArgs);
                    animals.Add(animal);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var animal in animals)
            {
                sb.AppendLine(animal.ToString());
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
