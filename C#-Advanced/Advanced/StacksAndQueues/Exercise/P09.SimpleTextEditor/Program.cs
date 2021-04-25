using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P09.SimpleTextEditor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var myStack = new Stack<string>();

            var sb = new StringBuilder();
            myStack.Push(sb.ToString());

            for (var i = 0; i < count; i++)
            {
                var cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var cmdType = cmdArgs[0];

                if (cmdType == "1")
                {
                    var text = cmdArgs[1];

                    sb.Append(text);
                    myStack.Push(sb.ToString());
                }
                else if (cmdType == "2")
                {
                    var length = int.Parse(cmdArgs[1]);

                    sb.Remove(sb.Length - length, length);
                    myStack.Push(sb.ToString());
                }
                else if (cmdType == "3")
                {
                    var index = int.Parse(cmdArgs[1]) - 1;

                    Console.WriteLine(sb[index]);
                }
                else if (cmdType == "4")
                {
                    myStack.Pop();
                    sb = new StringBuilder();
                    sb.Append(myStack.Peek());
                }
            }
        }
    }
}