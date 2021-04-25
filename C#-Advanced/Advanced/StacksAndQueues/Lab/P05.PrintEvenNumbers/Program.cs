using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> allNumbers = new Queue<int>(numbers);
            Queue<int> evenNumbers = new Queue<int>();

            while (allNumbers.Any())
            {
                if (allNumbers.Peek() % 2 == 0)
                {
                    evenNumbers.Enqueue(allNumbers.Dequeue());
                }
                else
                {
                    allNumbers.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
