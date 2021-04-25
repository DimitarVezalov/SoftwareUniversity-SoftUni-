using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var countries = new Dictionary<string, Dictionary<string, List<string>>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] countryArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string continent = countryArgs[0];
                string country = countryArgs[1];
                string city = countryArgs[2];

                if (!countries.ContainsKey(continent))
                {
                    countries[continent] = new Dictionary<string, List<string>>();
                }

                if (!countries[continent].ContainsKey(country))
                {
                    countries[continent][country] = new List<string>();
                }

                countries[continent][country].Add(city);

            }

            foreach (var continent in countries)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
