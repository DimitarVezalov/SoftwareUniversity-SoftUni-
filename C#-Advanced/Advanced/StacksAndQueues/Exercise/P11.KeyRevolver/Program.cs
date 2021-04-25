using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace P11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bulletsArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locksArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsArr);
            Queue<int> locks = new Queue<int>(locksArr);

            int counter = 0;
            while (bullets.Any() && locks.Any())
            {
                if (bullets.Pop() <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                counter++;
                if (counter == gunBarrelSize && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    counter = 0;
                }
            }

            int bulletsFired = bulletsArr.Length - bullets.Count;

            PrintOutput(bulletPrice, intelligenceValue, bullets, locks, bulletsFired);

        }

        private static void PrintOutput(int bulletPrice, int intelligenceValue, Stack<int> bullets, Queue<int> locks, int bulletsFired)
        {
            if (bullets.Count >= locks.Count)
            {
                int profit = intelligenceValue - bulletsFired * bulletPrice;

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${profit}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
