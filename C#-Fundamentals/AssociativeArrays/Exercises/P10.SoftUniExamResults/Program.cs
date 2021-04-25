using System;
using System.Linq;
using System.Collections.Generic;

namespace P10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string command;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] cmdArgs = command
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = cmdArgs[0];

                if (cmdArgs.Length == 3)
                {
                    string language = cmdArgs[1];
                    int points = int.Parse(cmdArgs[2]);

                    if (!results.ContainsKey(name))
                    {
                        results[name] = 0;
                    }

                    if (points > results[name])
                    {
                        results[name] = points;
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions[language] = 0;
                    }

                    submissions[language]++;
                }
                else
                {
                    results.Remove(name);
                }
                    
            }

            Console.WriteLine("Results:");
            foreach (var kvp in results.OrderByDescending(r => r.Value).ThenBy(r => r.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in submissions.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
