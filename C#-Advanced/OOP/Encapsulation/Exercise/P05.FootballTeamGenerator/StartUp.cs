using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] cmdArgs = command
                     .Split(';')
                     .ToArray();

                string cmdName = cmdArgs[0];
                string teamName = cmdArgs[1];

                if (cmdName == "Team")
                {
                    try
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                else if (cmdName == "Add")
                {
                    Team team = teams.FirstOrDefault(t => t.Name == teamName);

                    if (team == null)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }

                    string playerName = cmdArgs[2];
                    int endurance = int.Parse(cmdArgs[3]);
                    int sprint = int.Parse(cmdArgs[4]);
                    int dribble = int.Parse(cmdArgs[5]);
                    int passing = int.Parse(cmdArgs[6]);
                    int shooting = int.Parse(cmdArgs[7]);

                    try
                    {
                        Player player = new Player(playerName, endurance,sprint, dribble, passing, shooting);
                        team.AddPlayer(player);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                else if (cmdName == "Remove")
                {
                    Team team = teams.FirstOrDefault(t => t.Name == teamName);

                    if (team != null)
                    {
                        string playerName = cmdArgs[2];

                        if (!team.RemovePlayer(playerName))
                        {
                            Console.WriteLine($"Player {playerName} is not in {team.Name} team.");
                        }
                    }

                }
                else if (cmdName == "Rating")
                {
                    if (!teams.Any(t => t.Name == teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                    else
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        Console.WriteLine($"{teamName} - {team.OverallRating}");
                    }
                }
            }
        }
    }
}
