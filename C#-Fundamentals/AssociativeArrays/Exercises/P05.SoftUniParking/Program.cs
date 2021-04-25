using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                string user = cmdArgs[1];

                if (cmdType == "register")
                {
                    string licensePlate = cmdArgs[2];

                    if (!users.ContainsKey(user))
                    {
                        users[user] = licensePlate;
                        Console.WriteLine($"{user} registered {licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }

                }
                else if (cmdType == "unregister")
                {
                    if (users.ContainsKey(user))
                    {
                        users.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }

                }

            }

            foreach (var kvp in users)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
