using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.BalancedParenthesis
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var expression = Console.ReadLine();

            if (expression.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            var myStack = new Stack<char>();

            var areBalanced = true;

            foreach (var currChar in expression)
            {
                if (currChar == '(' || currChar == '{' || currChar == '[')
                {
                    myStack.Push(currChar);
                }
                else
                {
                    bool areEqual = CheckEquality(myStack, currChar);

                    if (areEqual)
                    {
                        myStack.Pop();
                    }
                    else
                    {
                        areBalanced = false;
                        break;
                    }

                }

            }

            Console.WriteLine(areBalanced ? "YES" : "NO");
        }

        private static bool CheckEquality(Stack<char> myStack, char currChar)
        {
            return (currChar == ')' && myStack.Peek() == '(') ||
                            (currChar == '}' && myStack.Peek() == '{') ||
                            (currChar == ']' && myStack.Peek() == '[');
        }
    }
}