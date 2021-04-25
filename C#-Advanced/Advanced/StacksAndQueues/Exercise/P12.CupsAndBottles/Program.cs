using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottlesArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(bottlesArr);
            Queue<int> cups = new Queue<int>(cupsArr);

            int wastedWater = 0;

            while (bottles.Any() && cups.Any())
            {
                if (bottles.Peek() >= cups.Peek())
                {
                    wastedWater += bottles.Pop() - cups.Dequeue();
                }
                else
                {
                    int currCup = cups.Peek();

                    while (currCup > 0)
                    {
                        currCup -= bottles.Pop();
                    }

                    cups.Dequeue();
                    wastedWater += Math.Abs(currCup);
                }
            }

            PrintOutput(bottles, cups, wastedWater);
        }

        private static void PrintOutput(Stack<int> bottles, Queue<int> cups, int wastedWater)
        {
            if (bottles.Count > cups.Count)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cups.Count > bottles.Count)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
