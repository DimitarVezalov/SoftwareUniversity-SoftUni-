using System;
using System.Linq;

namespace P02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> func = GetArrayCount;
            Console.WriteLine(func(numbers));

            func = GetArraySum;
            Console.WriteLine(func(numbers));
        }

        static int GetArraySum(int[] array) => array.Sum();
        static int GetArrayCount(int[] array) => array.Count();

    }
}
