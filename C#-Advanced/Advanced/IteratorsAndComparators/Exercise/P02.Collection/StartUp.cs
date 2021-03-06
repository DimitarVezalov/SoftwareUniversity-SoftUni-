using System;
using System.Linq;

namespace P02.Collection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] CreateArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            ListyIterator<string> listyIterator = new ListyIterator<string>(CreateArgs.Skip(1).ToArray());

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (command == "PrintAll")
                {
                    foreach (var item in listyIterator)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}
