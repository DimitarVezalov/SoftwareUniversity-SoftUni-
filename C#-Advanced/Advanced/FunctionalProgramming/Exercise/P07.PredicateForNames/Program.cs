using System;
using System.Linq;

namespace P07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Func<string, bool> filter = x => x.Length <= length;

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(filter)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
