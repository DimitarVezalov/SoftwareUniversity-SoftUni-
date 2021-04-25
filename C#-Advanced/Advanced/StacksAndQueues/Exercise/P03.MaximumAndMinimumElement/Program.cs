using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MaximumAndMinimumElement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var myStack = new Stack<int>();

            for (var i = 0; i < count; i++)
            {
                var queries = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                ProcessCommands(myStack, queries);
            }

            Console.WriteLine(string.Join(", ", myStack));
        }

        private static void ProcessCommands(Stack<int> myStack, int[] queries)
        {
            if (queries[0] == 1)
            {
                myStack.Push(queries[1]);
            }
            else if (queries[0] == 2)
            {
                if (myStack.Any())
                {
                    myStack.Pop();
                }
            }
            else
            {
                if (myStack.Any())
                {
                    if (queries[0] == 3)
                    {
                        Console.WriteLine(myStack.Max());
                    }
                    else
                    {
                        Console.WriteLine(myStack.Min());
                    }
                }
            }
        }
    }
}