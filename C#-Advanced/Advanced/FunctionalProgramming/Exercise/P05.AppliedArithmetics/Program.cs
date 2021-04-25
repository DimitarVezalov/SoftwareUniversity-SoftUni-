using System;
using System.Linq;

namespace P05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            Func<int, string, int> aritmeticFunc = (num, input) =>
            {
                if (input == "add")
                {
                    num += 1;
                }
                else if (input == "multiply")
                {
                    num *= 2;
                }
                else if (input == "subtract")
                {
                    num -= 1;
                }

                return num;
            };

            Action<int[], string> action = (arr, input) =>
            {
                if (input == "print")
                {
                    Console.WriteLine(string.Join(" ", arr));
                }
                else if (input == "end")
                {
                    Environment.Exit(0);
                }
            };
         

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "add" || input == "multiply" || input == "subtract")
                {
                    numbers = numbers
                        .Select(x => aritmeticFunc(x, input))
                        .ToArray();
                }
                else
                {
                    action(numbers, input);
                }
            }

        }
    }
}
