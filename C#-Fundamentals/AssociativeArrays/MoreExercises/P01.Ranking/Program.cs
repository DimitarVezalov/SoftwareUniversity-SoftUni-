using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> usersSubmissions = new Dictionary<string, Dictionary<string, int>>();

            string contestInfo;
            while ((contestInfo = Console.ReadLine()) != "end of contests")
            {
                AddContests(contests, contestInfo);
            }

            string submissionsInfo;
            while ((submissionsInfo = Console.ReadLine()) != "end of submissions")
            {
                AddSubmissions(contests, usersSubmissions, submissionsInfo);

            }

            PrintBestCandidate(usersSubmissions);
            Console.WriteLine("Ranking:");
            PrintSubmissions(usersSubmissions);
        }

        private static void PrintSubmissions(Dictionary<string, Dictionary<string, int>> usersSubmissions)
        {
            foreach (var kvp in usersSubmissions.OrderBy(u => u.Key))
            {
                Console.WriteLine(kvp.Key);

                foreach (var kvp1 in kvp.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"#  {kvp1.Key} -> {kvp1.Value}");
                }
            }
        }

        private static void PrintBestCandidate(Dictionary<string, Dictionary<string, int>> users)
        {
            KeyValuePair<string, Dictionary<string, int>> bestCandidate = users
                            .OrderByDescending(x => x.Value.Values.Sum())
                            .First();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
        }

        private static void AddSubmissions(Dictionary<string, string> contests, Dictionary<string, Dictionary<string, int>> users, string submissionsInfo)
        {
            string[] submissionsArgs = submissionsInfo
                                .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            string contest = submissionsArgs[0];
            string password = submissionsArgs[1];
            string userName = submissionsArgs[2];
            int points = int.Parse(submissionsArgs[3]);

            if (contests.ContainsKey(contest) && contests[contest] == password)
            {

                if (!users.ContainsKey(userName))
                {
                    users[userName] = new Dictionary<string, int>();
                }

                if (!users[userName].ContainsKey(contest))
                {
                    users[userName].Add(contest, 0);
                }

                if (points > users[userName][contest])
                {
                    users[userName][contest] = points;
                }
            }
        }

        private static void AddContests(Dictionary<string, string> contests, string contestInfo)
        {
            string[] contestArgs = contestInfo
                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string contestName = contestArgs[0];
            string contestPassword = contestArgs[1];

            if (!contests.ContainsKey(contestName))
            {
                contests[contestName] = "";
            }

            contests[contestName] = contestPassword;
        }
    }
}
