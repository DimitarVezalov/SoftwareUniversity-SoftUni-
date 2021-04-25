using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.GenericSwapMethodString
{
    partial class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();

                Box<string> box = new Box<string>(value);
                boxes.Add(box);
            }

            string[] swapCommands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int firstIndex = int.Parse(swapCommands[0]);
            int secondIndex = int.Parse(swapCommands[1]);

            Swap<string>(boxes, firstIndex, secondIndex);

            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }

        }

        public static void Swap<T>(List<Box<T>> list, int firstIndex, int secondIndex)
        {
            var firstElement = list[firstIndex];
            var secondElement = list[secondIndex];

            list[firstIndex] = secondElement;
            list[secondIndex] = firstElement;
        }
    }
    
}
