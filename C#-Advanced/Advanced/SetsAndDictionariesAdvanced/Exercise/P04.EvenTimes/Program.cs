using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double  currNumber = double.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currNumber))
                {
                    numbers[currNumber] = 0;
                }

                numbers[currNumber]++;
            }

            double number = numbers
                .Where(x => x.Value % 2 == 0)
                .Select(x => x.Key)
                .FirstOrDefault();

            Console.WriteLine(number);
        }
    }
}
