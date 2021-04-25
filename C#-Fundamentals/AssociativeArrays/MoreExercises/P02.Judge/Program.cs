using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string command;
            while ((command = Console.ReadLine()) != "no more time")
            {
                string[] cmdArgs = command
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string userName = cmdArgs[0];
                string contestName = cmdArgs[1];
                int points = int.Parse(cmdArgs[2]);

                if (!contests.ContainsKey(contestName))
                {
                    contests[contestName] = new Dictionary<string, int>();
                }

                if (!contests[contestName].ContainsKey(userName))
                {
                    contests[contestName][userName] = 0;
                }

                if (points > contests[contestName][userName])
                {
                    contests[contestName][userName] = points;
                }

                if (!users.ContainsKey(userName))
                {
                    users[userName] = new Dictionary<string, int>();
                }

                if (!users[userName].ContainsKey(contestName))
                {
                    users[userName][contestName] = 0;
                }

                if (points > users[userName][contestName])
                {
                    users[userName][contestName] = points;
                }
            }

            foreach (var outerKvp in contests)
            {
                Console.WriteLine($"{outerKvp.Key}: {outerKvp.Value.Count} participants");
                int count = 1;
                foreach (var innerKvp in outerKvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{count}. {innerKvp.Key} <::> {innerKvp.Value}");
                    count++;
                }
            }

            Console.WriteLine("Individual standings:");
            int counter = 1;
            foreach (var kvp in users.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counter}. {kvp.Key} -> {kvp.Value.Values.Sum()}");
                counter++;
            }
        }
    }
}
