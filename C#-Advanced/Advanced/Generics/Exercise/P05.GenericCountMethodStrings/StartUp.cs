using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> values = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();

                values.Add(value);
                
            }

            Box<string> box = new Box<string>(values);

            string compareValue = Console.ReadLine();

            Console.WriteLine(box.CountBiggerElements(compareValue));
               
        }
    }
}
