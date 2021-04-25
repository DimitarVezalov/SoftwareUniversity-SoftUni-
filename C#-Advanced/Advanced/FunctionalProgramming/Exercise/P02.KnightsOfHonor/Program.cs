using System;
using System.Linq;

namespace P02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = msg => Console.WriteLine($"Sir {msg}");

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
