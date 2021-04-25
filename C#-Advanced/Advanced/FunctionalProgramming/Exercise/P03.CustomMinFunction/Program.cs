using System;
using System.Linq;

namespace P03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minElementFunc = arr =>
            {
                int min = int.MaxValue;

                foreach (var number in arr)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }

                return min;
            };

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int minElement = minElementFunc(numbers);
            Console.WriteLine(minElement);
        }
    }
}
