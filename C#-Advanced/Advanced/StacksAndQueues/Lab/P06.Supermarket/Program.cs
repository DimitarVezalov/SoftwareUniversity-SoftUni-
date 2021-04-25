using System;
using System.Collections.Generic;

namespace P06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, names));
                    names.Clear();
                }
                else if (input == "End")
                {
                    break;
                }
                else
                {
                    names.Enqueue(input);
                }

            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
