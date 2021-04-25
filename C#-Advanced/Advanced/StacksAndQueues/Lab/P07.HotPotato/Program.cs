using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namesArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int count = int.Parse(Console.ReadLine());

            Queue<string> names = new Queue<string>(namesArr);

            while (names.Count > 1)
            {
                int counter = 1;

                while (counter != count)
                {
                   names.Enqueue(names.Dequeue());
                   counter++;
                }

                Console.WriteLine($"Removed {names.Dequeue()}");
            }

            Console.WriteLine($"Last is {names.Peek()}");
        }
    }
}
