using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex thresholdRegex = new Regex(@"\d");
            Regex emojis = new Regex(@"(\:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1");

            MatchCollection numberMatches = thresholdRegex.Matches(input);

            long threshold = 1; 
            numberMatches
                .Select(m => m.Value)
                .Select(int.Parse)
                .ToList()
                .ForEach(x => threshold *= x);

            MatchCollection emojisMatches = emojis.Matches(input);

            List<string> coolEmojies = new List<string>();

            foreach (Match match in emojisMatches)
            {
                long currentCoolnes = match.
                    Groups["emoji"].Value
                    .ToCharArray()
                    .Sum(c => c);

                if (currentCoolnes > threshold)
                {
                    coolEmojies.Add($"{match.Groups[1]}{match.Groups["emoji"].Value}{match.Groups[1]}");
                }
            }

            Console.WriteLine($"Cool threshold: {threshold}");

            Console.WriteLine($"{emojisMatches.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join(Environment.NewLine, coolEmojies));
        }
    }
}
