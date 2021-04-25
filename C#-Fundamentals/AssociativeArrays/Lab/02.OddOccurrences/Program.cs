using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split()
                .ToArray();

            Dictionary<string, int> oddOccurrences = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!oddOccurrences.ContainsKey(word))
                {
                    oddOccurrences[word] = 0;
                }

                oddOccurrences[word]++;
            }

            foreach (var kvp in oddOccurrences)
            {
                if (kvp.Value % 2 != 0)
                {
                    Console.Write($"{kvp.Key} ");
                }
            }
        }
    }
}
