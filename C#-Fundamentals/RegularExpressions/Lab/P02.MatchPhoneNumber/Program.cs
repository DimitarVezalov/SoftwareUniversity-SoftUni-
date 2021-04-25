using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\+359(-| )2\1[0-9]{3}\1[0-9]{4}\b";

            string numbers = Console.ReadLine();

            MatchCollection matches = Regex.Matches(numbers, patern);

            //List<string> validNumbers = matches.Select(m => m.Value).ToList();

            Console.WriteLine(string.Join(", ",matches));
        }
    }
}
