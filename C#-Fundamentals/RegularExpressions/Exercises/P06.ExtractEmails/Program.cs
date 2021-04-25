using System;
using System.Text.RegularExpressions;

namespace P06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b(?<!\S)[a-z][a-z0-9\.\-_]+[a-z0-9]*@[a-z][a-z\-]+\.[a-z][a-z\.]+[a-z]?\b");

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
