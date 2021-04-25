using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> myStack = new Stack<char>();

            foreach (var c in input)
            {
                myStack.Push(c);
            }

            Console.WriteLine(string.Join("", myStack));
        }
    }
}
