using System;
using System.Linq;

namespace P03.CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> customStack = new CustomStack<int>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Pop")
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                        
                    }
                }
                else
                {
                    int[] elements = command
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .Select(int.Parse)
                        .ToArray();

                    customStack.Push(elements);
                }
            }

            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
