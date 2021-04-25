using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();

            int unlikedMeals = 0;

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                string guestName = cmdArgs[1];
                string meal = cmdArgs[2];

                if (cmdType == "Like")
                {
                    if (!guests.ContainsKey(guestName))
                    {
                        guests[guestName] = new List<string>();
                    }

                    if (!guests[guestName].Contains(meal))
                    {
                        guests[guestName].Add(meal);
                    }

                }
                else if (cmdType == "Unlike")
                {
                    if (guests.ContainsKey(guestName))
                    {
                        if (guests[guestName].Contains(meal))
                        {
                            guests[guestName].Remove(meal);
                            unlikedMeals++;
                            Console.WriteLine($"{guestName} doesn't like the {meal}.");
                        }
                        else
                        {
                            Console.WriteLine($"{guestName} doesn't have the {meal} in his/her collection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is not at the party.");
                    }
                }
            }

            foreach (var kvp in guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
            }

            Console.WriteLine($"Unliked meals: {unlikedMeals}");


        }
    }
}
