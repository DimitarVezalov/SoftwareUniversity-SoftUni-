using System;
using System.Linq;

namespace P01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(", ")
                .Select(IntParser)
                .Where(CheckEven)
                .OrderBy(x => x)));
        }

        private static bool CheckEven(int number) => number % 2 == 0;

        private static int IntParser(string number) => int.Parse(number);
    }
}
