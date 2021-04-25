using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.BasicQueueOperations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cmdArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var myQueue = new Queue<int>(numbers);

            for (var i = 0; i < cmdArr[1]; i++)
            {
                myQueue.Dequeue();
            }

            string result = GetOutput(myQueue, cmdArr[2]);

            Console.WriteLine(result);
        }

        private static string GetOutput(Queue<int> queue, int num)
        {
            if (queue.Count == 0)
            {
                return "0";
            }
            else if (queue.Contains(num))
            {
                return "true";
            }
            else
            {
                return $"{queue.Min()}";
            }

        }
    }
}