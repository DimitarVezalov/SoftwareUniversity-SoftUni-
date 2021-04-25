using System;
using System.Linq;

namespace P01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = msg => Console.WriteLine(msg);

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var name in names)
            {
                printer(name);
            }
                
        }
    }
}
