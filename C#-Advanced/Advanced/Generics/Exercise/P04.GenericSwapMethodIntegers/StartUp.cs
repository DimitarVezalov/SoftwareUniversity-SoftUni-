using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(value);
                boxes.Add(box);
            }

            string[] swapCommands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int firstIndex = int.Parse(swapCommands[0]);
            int secondIndex = int.Parse(swapCommands[1]);

            Swap<int>(boxes, firstIndex, secondIndex);

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
