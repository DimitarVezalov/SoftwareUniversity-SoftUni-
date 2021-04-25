using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBox = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondBox = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueItems = new Queue<int>(firstBox);
            Stack<int> stackItems = new Stack<int>(secondBox);

            List<int> claimedItems = new List<int>();

            while (queueItems.Any() && stackItems.Any())
            {

                int summedItem = stackItems.Peek() + queueItems.Peek();

                if (summedItem % 2 == 0)
                {
                    claimedItems.Add(stackItems.Pop() + queueItems.Dequeue());
                }
                else
                {
                    queueItems.Enqueue(stackItems.Pop());
                }
            }

            if (!queueItems.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int claimedItemsSum = claimedItems.Sum();

            if (claimedItemsSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItemsSum}");
            }
        }
    }
}
