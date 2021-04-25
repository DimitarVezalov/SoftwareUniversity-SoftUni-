using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesArr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] rosesArr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> lilies = new Stack<int>(liliesArr);
            Queue<int> roses = new Queue<int>(rosesArr);

            List<int> storedFlowers = new List<int>();

            int wreathCount = 0;

            while (lilies.Any() && roses.Any())
            {
                int currentSum = lilies.Peek() + roses.Peek();

                if (currentSum == 15)
                {
                    wreathCount++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (currentSum > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    storedFlowers.Add(lilies.Pop());
                    storedFlowers.Add(roses.Dequeue());
                }
            }

            if (storedFlowers.Any())
            {
                int additionalWreaths = storedFlowers.Sum() / 15;
                wreathCount += additionalWreaths;
            }

            if (wreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }
        }
    }
}
