using System;
using System.Collections;
using System.Collections.Generic;

namespace P04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int index = stack.Pop();
                    int length = i - index + 1;

                    string curExpression = expression.Substring(index, length);
                    Console.WriteLine(curExpression);
                }
            }
        }
    }
}
