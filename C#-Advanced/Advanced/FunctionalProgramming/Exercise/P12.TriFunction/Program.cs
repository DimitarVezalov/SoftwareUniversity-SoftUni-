using System;
using System.Linq;

namespace P12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Func<string, int, bool> filter = (name, num) =>
            {
                int sum = 0;
                foreach (var symbol in name)
                {
                    sum += symbol;
                }

                return sum >= num;
            };

            string[] names = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Console.WriteLine(names.FirstOrDefault(x => filter(x,number)));
        }
    }
}
