using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> uniqueElements = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var element in elements)
                {
                    uniqueElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueElements));
        }
    }
}
