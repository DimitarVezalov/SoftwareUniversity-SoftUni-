using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> values = new Dictionary<double, int>();

            foreach (var item in array)
            {
                if (!values.ContainsKey(item))
                {
                    values[item] = 0;
                }

                values[item]++;
            }

            foreach (var kvp in values)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
