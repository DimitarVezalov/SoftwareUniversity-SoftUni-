using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggersFollowers = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> vloggersFollowing = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[1];

                if (cmdType == "joined")
                {
                    GetVloggers(vloggersFollowers, vloggersFollowing, cmdArgs);
                }
                else if (cmdType == "followed")
                {
                    string firstVlogger = cmdArgs[0];
                    string secondVlogger = cmdArgs[2];

                    if (vloggersFollowers.ContainsKey(firstVlogger) &&
                        vloggersFollowers.ContainsKey(secondVlogger))
                    {
                        if (firstVlogger == secondVlogger ||
                            vloggersFollowing[firstVlogger].Any(x => x == secondVlogger))
                        {
                            continue;
                        }

                        vloggersFollowing[firstVlogger].Add(secondVlogger);
                        vloggersFollowers[secondVlogger].Add(firstVlogger);
                    }

                }

            }

            vloggersFollowers = vloggersFollowers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => vloggersFollowing[x.Key].Count)
                .ToDictionary(k => k.Key, v => v.Value);

            PrintOutput(vloggersFollowers, vloggersFollowing);

        }

        private static void GetVloggers(Dictionary<string, List<string>> vloggersFollowers, Dictionary<string, List<string>> vloggersFollowing, string[] cmdArgs)
        {
            string vloggerName = cmdArgs[0];

            if (!vloggersFollowers.ContainsKey(vloggerName))
            {
                vloggersFollowers.Add(vloggerName, new List<string>());
            }

            if (!vloggersFollowing.ContainsKey(vloggerName))
            {
                vloggersFollowing.Add(vloggerName, new List<string>());
            }
        }
        private static void PrintOutput(Dictionary<string, List<string>> vloggersFollowers, Dictionary<string, List<string>> vloggersFollowing)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggersFollowers.Count} vloggers in its logs.");

            int count = 1;

            foreach (var kvp in vloggersFollowers)
            {
                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value.Count} followers," +
                        $" {vloggersFollowing[kvp.Key].Count} following");

                if (count == 1)
                {
                    foreach (var follower in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }
}
