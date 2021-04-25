using System;
using System.Collections.Generic;
using System.Text;

namespace P05.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder words = new StringBuilder();
            StringBuilder symbols = new StringBuilder();

            foreach (var character in text)
            {
                if (Char.IsDigit(character))
                {
                    digits.Append(character);
                }
                else if (Char.IsLetter(character))
                {
                    words.Append(character);
                }
                else
                {
                    symbols.Append(character);
                }

            }

            Console.WriteLine($"{digits.ToString()}\n{words.ToString()}\n{symbols.ToString()}");
        }
    }
}
