using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceSides = new Dictionary<string, List<string>>();

            string[] separators = { " | ", " -> " };

            string command;
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] cmdArgs = command
                    .Split(separators,StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command.Contains("|"))
                {
                    string forceSide = cmdArgs[0];
                    string forceUser = cmdArgs[1];

                    if (!forceSides.ContainsKey(forceSide))
                    {
                        forceSides[forceSide] = new List<string>();
                    }

                    if (!forceSides.Any(x => x.Value.Contains(forceUser)))
                    {
                        forceSides[forceSide].Add(forceUser);
                    }

                }
                else if (command.Contains("->"))
                {
                    string forceUser = cmdArgs[0];
                    string forceSide = cmdArgs[1];

                    foreach (var kvp in forceSides)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            kvp.Value.Remove(forceUser);
                        }

                    }

                    if (!forceSides.ContainsKey(forceSide))
                    {
                        forceSides[forceSide] = new List<string>();
                    }

                    forceSides[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

            }

            forceSides = forceSides
                .Where(s => s.Value.Count > 0)
                .OrderByDescending(s => s.Value.Count)
                .ThenBy(s => s.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in forceSides)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                foreach (var item in kvp.Value.OrderBy(u => u))
                {
                    Console.WriteLine($"! {item}");
                }
            }
        }
    }
}
