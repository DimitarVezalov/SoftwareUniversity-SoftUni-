using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Regex regex = new Regex
                (@"(.+)>(?<first>\d{3})\|(?<second>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<fourth>[^\>\<]{3})<\1");

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string first = match.Groups["first"].Value;
                    string second = match.Groups["second"].Value;
                    string third = match.Groups["third"].Value;
                    string fourth = match.Groups["fourth"].Value;

                    string password = first + second + third + fourth;

                    Console.WriteLine($"Password: {password}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
