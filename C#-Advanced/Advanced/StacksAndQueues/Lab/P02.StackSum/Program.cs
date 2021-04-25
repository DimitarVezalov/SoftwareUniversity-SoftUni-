using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Stack<int> myStack = new Stack<int>();

            foreach (var num in numbers)
            {
                myStack.Push(num);
            }

            string command;
            while ((command =Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (cmdArgs[0].ToLower() == "add")
                {
                    foreach (var token in cmdArgs.Skip(1))
                    {
                        myStack.Push(int.Parse(token));
                    }
                }
                else if (cmdArgs[0].ToLower() == "remove")
                {
                    int count = int.Parse(cmdArgs[1]);

                    if (count <= myStack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            myStack.Pop();
                        }
                    }
                   
                }
            }

            Console.WriteLine($"Sum: {myStack.Sum()}");
        }
    }
}
