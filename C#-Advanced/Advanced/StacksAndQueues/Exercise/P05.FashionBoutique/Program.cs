using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FashionBoutique
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var clothesArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rackCapacity = int.Parse(Console.ReadLine());

            var clothes = new Stack<int>(clothesArr);

            if (clothes.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var racksCount = 1;
            var sum = 0;

            while (clothes.Any())
            {
                sum += clothes.Peek();

                if (sum <= rackCapacity)
                {
                    clothes.Pop();
                }
                else
                {
                    sum = 0;
                    racksCount++;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}