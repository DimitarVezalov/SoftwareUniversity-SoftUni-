using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<double> first = new HashSet<double>();
            HashSet<double> second = new HashSet<double>();

            double[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < sizes[0]; i++)
            {
                double number = double.Parse(Console.ReadLine());
                first.Add(number);
            }

            for (int i = 0; i < sizes[1]; i++)
            {
                double number = double.Parse(Console.ReadLine());
                second.Add(number);
            }

            first.IntersectWith(second);

            Console.WriteLine(string.Join(" ", first));
        }
    }
}
