using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                GetClothes(clothes, inputArgs);
            }

            string[] wantedClothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            PrintOutput(clothes, wantedClothes);
        }

        private static void GetClothes(Dictionary<string, Dictionary<string, int>> clothes, string[] inputArgs)
        {
            string color = inputArgs[0];

            string[] clothesArgs = inputArgs[1]
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (!clothes.ContainsKey(color))
            {
                clothes[color] = new Dictionary<string, int>();
            }

            foreach (var item in clothesArgs)
            {
                if (!clothes[color].ContainsKey(item))
                {
                    clothes[color][item] = 0;
                }

                clothes[color][item]++;
            }
        }

        private static void PrintOutput(Dictionary<string, Dictionary<string, int>> clothes, string[] wantedClothes)
        {
            foreach (var kvp in clothes)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var item in kvp.Value)
                {
                    if (kvp.Key == wantedClothes[0] && item.Key == wantedClothes[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }

                }
            }
        }
    }
}
