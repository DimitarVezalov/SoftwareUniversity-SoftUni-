using System;
using System.Linq;

namespace P03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Func<string, bool> isUpper = x => char.IsUpper(x[0]);

            string[] words = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
