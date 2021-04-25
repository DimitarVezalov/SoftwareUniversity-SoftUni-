using System;
using System.Collections.Generic;

namespace P06.GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<double> values = new List<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double value = double.Parse(Console.ReadLine());

                values.Add(value);

            }

            Box<double> box = new Box<double>(values);

            double compareValue = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CountBiggerElements(compareValue));

        }
    }
}
