using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (char character in text)
            {
                if (!counts.ContainsKey(character))
                {
                    counts[character] = 0;
                }

                counts[character]++;             
            }

            foreach (var kvp in counts.Where(kvp => kvp.Key != ' '))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
