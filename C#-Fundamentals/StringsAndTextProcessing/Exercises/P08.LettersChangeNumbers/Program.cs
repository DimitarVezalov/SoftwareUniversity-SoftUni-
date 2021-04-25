using System;
using System.Linq;
using System.Collections.Generic;

namespace P08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> alphabet = new Dictionary<char, int>();
            int count = 1;
            for (char i = 'A'; i <= 'Z' ; i++)
            {
                alphabet[i] = count;
                count++;
            }

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double sum = 0;

            foreach (var word in input)
            {
                string numberAsText = word.Substring(1, word.Length - 2);
                double number = double.Parse(numberAsText);

                if (char.IsUpper(word[0]))
                {
                    number /= alphabet[word[0]];
                }
                else
                {
                    char current = char.ToUpper(word[0]);
                    number *= alphabet[current];
                }
                
                if (char.IsUpper(word[word.Length - 1]))
                {
                    number -= alphabet[word[word.Length - 1]];
                }
                else
                {
                    char current = char.ToUpper(word[word.Length - 1]);
                    number += alphabet[current];
                }

                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
