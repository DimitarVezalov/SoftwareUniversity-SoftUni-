using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int count = range[1] - range[0] + 1;

            int[] numbers = Enumerable
                .Range(start, count)
                .ToArray();

            string evenOrOdd = Console.ReadLine();

            Func<int, bool> filter = evenOrOdd switch
            {
                "odd" => x => x % 2 != 0,
                "even" => x => x % 2 == 0,
                _ => x => true
            };

            Console.WriteLine(string.Join(" ", numbers.Where(filter)));
        }
    }
}
