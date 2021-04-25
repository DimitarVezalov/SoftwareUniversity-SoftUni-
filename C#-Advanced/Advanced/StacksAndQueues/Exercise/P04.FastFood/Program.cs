using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FastFood
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var foodQuantity = int.Parse(Console.ReadLine());

            var ordersArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var orders = new Queue<int>(ordersArr);

            Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                if (foodQuantity >= orders.Peek())
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            PrintResult(orders);
        }

        private static void PrintResult(Queue<int> orders)
        {
            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}