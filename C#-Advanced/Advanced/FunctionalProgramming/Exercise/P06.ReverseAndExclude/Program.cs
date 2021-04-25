using System;
using System.Linq;

namespace P06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int n = int.Parse(Console.ReadLine());

            Action<int[], int[]> reverseAction = (arr, reversed) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    reversed[i] = arr[arr.Length - 1 - i];
                }
            };

            int[] reversed = new int[numbers.Length];
            reverseAction(numbers, reversed);

            Func<int, int, bool> filter = (a, b) => a % b == 0;

            Console.WriteLine(string.Join(" ", reversed.Where(x => !filter(x, n))));
        }
    }
}
