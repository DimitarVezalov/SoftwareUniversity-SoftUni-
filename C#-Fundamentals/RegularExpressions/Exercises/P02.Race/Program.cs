using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> results = new Dictionary<string, int>();

            for (int i = 0; i < names.Length; i++)
            {
                results[names[i]] = 0;
            }

            string argsPatern = "\\W";
            string namePatern = "\\d";

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                string[] personArgsArr = Regex.Split(input, argsPatern);
                string personArgsStr = string.Join("",personArgsArr);

                string[] nameArr = Regex.Split(personArgsStr, namePatern);
                string name = string.Join("", nameArr);

                int currentDistance = 0;

                foreach (var symbol in personArgsStr)
                {
                    if (char.IsDigit(symbol))
                    {
                        currentDistance += int.Parse(symbol.ToString());
                    }
                }

                if (results.ContainsKey(name))
                {
                     results[name] += currentDistance;
                }
            }

            int count = 1;
            foreach (var result in results.OrderByDescending(r => r.Value))
            {
                string postfix = GetPostfix(count);

                Console.WriteLine($"{count}{postfix} place: {result.Key}");

                count++;
                if (count > 3)
                {
                    break;
                }
            }
        }

        private static string GetPostfix(int count)
        {
            string postfix = "";

            if (count == 1)
            {
                postfix = "st";
            }
            else if (count == 2)
            {
                postfix = "nd";
            }
            else if (count == 3)
            {
                postfix = "rd";
            }

            return postfix;
        }
    }
}
