using System;
using System.Linq;

namespace P09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = Enumerable.Range(1, n).ToArray();

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> filter = (x, arr) =>
            {
                foreach (var item in arr)
                {
                    if (x % item != 0)
                    {
                        return false;
                    }
                }

                return true;
            };

            Console.WriteLine(string.Join(" ", arr.Where(x => filter(x, dividers))));
        }
    }
}
