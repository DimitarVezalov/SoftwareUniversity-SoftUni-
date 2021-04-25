using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace P03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expresion = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> myStack = new Stack<string>();

            foreach (var element in expresion.Reverse())
            {
                myStack.Push(element);
            }

            int result = 0;

            while (myStack.Any())
            {
                if (myStack.Peek() == "+")
                {
                    myStack.Pop();
                    result += int.Parse(myStack.Pop());
                }
                else if (myStack.Peek() == "-")
                {
                    myStack.Pop();
                    result -= int.Parse(myStack.Pop());
                }
                else
                {
                    result += int.Parse(myStack.Pop());
                }
            }

            Console.WriteLine(result);

        }
    }
}
