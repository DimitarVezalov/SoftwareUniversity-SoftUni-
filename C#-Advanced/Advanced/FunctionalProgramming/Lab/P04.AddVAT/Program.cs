using System;
using System.Linq;

namespace P04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> addVat = x => Math.Round(x * 1.20m, 2);

            decimal[] numbers = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(addVat)
                .ToArray();


            Console.WriteLine(string.Join(Environment.NewLine, numbers));
        }
    }
}
