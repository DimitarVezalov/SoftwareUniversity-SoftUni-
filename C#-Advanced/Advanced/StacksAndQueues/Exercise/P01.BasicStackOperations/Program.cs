using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BasicStackOperations
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

            var myStack = new Stack<int>(numbers);

            for (var i = 0; i < cmdArr[1]; i++)
            {
                myStack.Pop();
            }

            string result = GetOutput(myStack, cmdArr[2]);

            Console.WriteLine(result);
        }

        private static string GetOutput(Stack<int> stack, int num)
        {
            if (stack.Count == 0)
            {
                return "0";
            }
            else if (stack.Contains(num))
            {
                return "true";
            }
            else
            {
                return $"{stack.Min()}";
            }

        }
    }
}