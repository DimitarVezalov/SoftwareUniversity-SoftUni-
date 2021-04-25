using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class City
    {
        public City(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }

        public string Name { get; set; }

        public int Population { get; set; }

        public int Gold { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<City> allCities = new List<City>();

            string cities;
            while ((cities = Console.ReadLine()) != "Sail")
            {
                string[] cityArgs = cities
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                TargetingCities(allCities, cityArgs);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = cmdArgs[0];
                string name = cmdArgs[1];

                if (type == "Plunder")
                {
                    Plunder(allCities, cmdArgs, name);
                }
                else if (type == "Prosper")
                {
                    Prosper(allCities, cmdArgs, name);

                }

            }

            PrintResult(allCities);

        }

        private static void TargetingCities(List<City> allCities, string[] cityArgs)
        {
            string name = cityArgs[0];
            int population = int.Parse(cityArgs[1]);
            int gold = int.Parse(cityArgs[2]);

            if (allCities.Any(c => c.Name == name))
            {
                City city = allCities.FirstOrDefault(c => c.Name == name);

                city.Population += population;
                city.Gold += gold;
            }
            else
            {
                City city = new City(name, population, gold);
                allCities.Add(city);
            }
        }     

        private static void Plunder(List<City> allCities, string[] cmdArgs, string name)
        {
            int peopleKilled = int.Parse(cmdArgs[2]);
            int goldStolen = int.Parse(cmdArgs[3]);

            City city = allCities.FirstOrDefault(c => c.Name == name);

            city.Population -= peopleKilled;
            city.Gold -= goldStolen;
            Console.WriteLine($"{name} plundered! {goldStolen} gold stolen, {peopleKilled} citizens killed.");
    
            if (city.Population <= 0 || city.Gold <= 0)
            {               
                allCities.Remove(city);
                Console.WriteLine($"{name} has been wiped off the map!");
            }
           
        }

        private static void Prosper(List<City> allCities, string[] cmdArgs, string name)
        {
            int goldAdded = int.Parse(cmdArgs[2]);

            if (goldAdded < 0)
            {
                Console.WriteLine($"Gold added cannot be a negative number!");
            }
            else
            {
                City city = allCities.FirstOrDefault(c => c.Name == name);
                city.Gold += goldAdded;
                Console.WriteLine($"{goldAdded} gold added to the city treasury." +
                    $" {name} now has {city.Gold} gold.");
            }
        }

        private static void PrintResult(List<City> allCities)
        {
            if (allCities.Any())
            {
                Console.WriteLine($"Ahoy, Captain! There are {allCities.Count} wealthy settlements to go to:");

                foreach (var city in allCities.OrderByDescending(c => c.Gold).ThenBy(c => c.Name))
                {

                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");

                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
