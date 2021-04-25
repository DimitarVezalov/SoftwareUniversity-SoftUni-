using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsInputPath = "../../../words.txt";
            string textInputPath = "../../../text.txt";
            string actualResultPath = "../../../actualResult.txt";
            string expectedResultPath = "../../../expectedResult.txt";


            List<string> words = File.ReadAllLines(wordsInputPath).ToList();

            Dictionary<string, int> wordsCounts = new Dictionary<string, int>();

            char[] delimiters = {',', '.', '?','-', '!', ' ' };

            foreach (var word in words)
            {
                wordsCounts[word] = 0;
            }

            string text = File.ReadAllText(textInputPath);

            foreach (var word in text.Split(delimiters))
            {
                if (wordsCounts.ContainsKey(word.ToLower()))
                {
                    wordsCounts[word.ToLower()]++;
                }
            }

            words = wordsCounts
                .Select(x => $"{x.Key} - {x.Value}")
                .ToList();

            File.WriteAllLines(actualResultPath, words);

            wordsCounts = wordsCounts
                .OrderByDescending(x => x.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            words = wordsCounts
                .Select(x => $"{x.Key} - {x.Value}")
                .ToList();

            File.WriteAllLines(expectedResultPath, words);
        }
    }
}
