using System;
using System.Text.RegularExpressions;

namespace P03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern =
                @"(?<day>[0][1-9]|[1-9][0-9])(?<separator>[\.|\-|\/])(?<month>[A-Z][a-z]{2})\2(?<year>[0-9]{4})";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, patern);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}
