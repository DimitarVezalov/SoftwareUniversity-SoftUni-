using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> sorted = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                double currentNumber = numbers[i];

                if (!sorted.ContainsKey(currentNumber))
                {
                    sorted[currentNumber] = 0;
                }

                sorted[currentNumber]++;
            }

            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

        }
    }
}
