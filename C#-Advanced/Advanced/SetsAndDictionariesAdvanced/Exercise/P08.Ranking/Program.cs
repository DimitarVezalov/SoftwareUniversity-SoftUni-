using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> usersInfo = new Dictionary<string, Dictionary<string, int>>();

            string contestInput;
            while ((contestInput = Console.ReadLine()) != "end of contests")
            {
                GetContests(contests, contestInput);
            }

            string userInput;
            while ((userInput = Console.ReadLine()) != "end of submissions")
            {
                GetUsers(contests, usersInfo, userInput);
            }

            PrintOutput(usersInfo);

        }

        private static void GetUsers(Dictionary<string, string> contests, Dictionary<string, Dictionary<string, int>> usersInfo, string userInput)
        {
            string[] userArgs = userInput
                .Split("=>")
                .ToArray();

            string contestName = userArgs[0];
            string contestPassword = userArgs[1];
            string userName = userArgs[2];
            int points = int.Parse(userArgs[3]);

            if (contests.ContainsKey(contestName) && contests[contestName] == contestPassword)
            {
                if (!usersInfo.ContainsKey(userName))
                {
                    usersInfo[userName] = new Dictionary<string, int>();
                }

                if (!usersInfo[userName].ContainsKey(contestName))
                {
                    usersInfo[userName][contestName] = 0;
                }

                if (usersInfo[userName][contestName] < points)
                {
                    usersInfo[userName][contestName] = points;
                }
            }
        }

        private static void GetContests(Dictionary<string, string> contests, string contestInput)
        {
            string[] contestArgs = contestInput
                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string contestName = contestArgs[0];
            string password = contestArgs[1];

            if (!contests.ContainsKey(contestName))
            {
                contests[contestName] = password;
            }
        }

        private static void PrintOutput(Dictionary<string, Dictionary<string, int>> usersInfo)
        {
            KeyValuePair<string, Dictionary<string, int>> best = usersInfo
                .OrderByDescending(x => x.Value.Values.Sum())
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {best.Key} with total {best.Value.Values.Sum()} points.");
            Console.WriteLine($"Ranking:");
            foreach (var kvp in usersInfo.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
