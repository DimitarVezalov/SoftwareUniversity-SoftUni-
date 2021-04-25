using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MOBAChallenger
{
    class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.Possitions = new Dictionary<string, int>();
        }

        public string Name { get; set; }

        public Dictionary<string, int> Possitions { get; set; }      
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                if (command.Contains("->"))
                {
                    string[] cmdArgs = command
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string name = cmdArgs[0];
                    string possition = cmdArgs[1];
                    int skillPoints = int.Parse(cmdArgs[2]);

                    if (!players.Any(p => p.Name == name))
                    {
                        Player player = new Player(name);
                        player.Possitions.Add(possition, skillPoints);

                        players.Add(player);
                    }
                    else
                    {
                        Player player = players.First(p => p.Name == name);

                        if (!player.Possitions.ContainsKey(possition))
                        {
                            player.Possitions[possition] = 0;
                        }

                        if (skillPoints > player.Possitions[possition])
                        {
                            player.Possitions[possition] = skillPoints;
                        }

                    }

                }
                else
                {
                    string[] cmdArgs = command
                        .Split(" vs ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string firstName = cmdArgs[0];
                    string secondName = cmdArgs[1];

                    if (players.Any(p => p.Name == firstName) && players.Any(p => p.Name == secondName))
                    {
                        Player firstPlayer = players.First(p => p.Name == firstName);
                        Player secondPlayer = players.First(p => p.Name == secondName);

                        bool isDuelPossible = false;

                        KeyValuePair<string, int> firstKvp = new KeyValuePair<string, int>();
                        KeyValuePair<string, int> secondKvp = new KeyValuePair<string, int>();

                        foreach (var kvp in firstPlayer.Possitions)
                        {
                            string currentPossition = kvp.Key;

                            foreach (var kvp1 in secondPlayer.Possitions)
                            {
                                if (kvp1.Key == currentPossition)
                                {
                                    firstKvp = kvp;
                                    secondKvp = kvp1;
                                    isDuelPossible = true;
                                    break;
                                }

                            }

                            if (isDuelPossible)
                            {
                                break;
                            }

                        }

                        if (isDuelPossible)
                        {
                            if (firstKvp.Value > secondKvp.Value)
                            {
                                players.Remove(secondPlayer);
                            }
                            else if (secondKvp.Value > firstKvp.Value)
                            {
                                players.Remove(firstPlayer);
                            }

                        }

                    }

                }
                
            }

            foreach (var player in players.OrderByDescending(p => p.Possitions.Values.Sum()).ThenBy(p => p.Name))
            {
                Console.WriteLine($"{player.Name}: {player.Possitions.Values.Sum()} skill");

                foreach (var kvp in player.Possitions.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
                {
                    Console.WriteLine($"- {kvp.Key} <::> {kvp.Value}");
                }
            }
        }
    }
}
