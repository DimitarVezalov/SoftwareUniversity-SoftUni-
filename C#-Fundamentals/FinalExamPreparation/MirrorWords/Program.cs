using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([#@])(?<firstWord>[A-Za-z]{3,})\1{2}(?<secondWord>[A-Za-z]{3,})\1");
            List<string> mirroredWords = new List<string>();

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                string firstWord = match.Groups["firstWord"].Value;
                string secondWord = match.Groups["secondWord"].Value;

                string reversed = ReverseWord(secondWord);

                if (firstWord == reversed)
                {
                    mirroredWords.Add($"{firstWord} <=> {secondWord}");
                }
            }

            string pairsOutput = matches.Count == 0 ? "No word pairs found!" : $"{matches.Count} word pairs found!";
            string wordsOutput = mirroredWords.Count == 0 ? "No mirror words!"
                    : $"The mirror words are:\n{string.Join(", ", mirroredWords)}";

            Console.WriteLine(pairsOutput);
            Console.WriteLine(wordsOutput);

           
        }

        private static string ReverseWord(string secondWord)
        {
            string reversed = "";

            for (int i = secondWord.Length - 1; i >= 0; i--)
            {
                reversed += secondWord[i];
            }

            return reversed;
        }
    }
}
