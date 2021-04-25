using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> validUsernames = new List<string>();

            foreach (var username in usernames)
            {
                if (username.Length < 3 || username.Length > 16)
                {
                    continue;
                }

                bool isValid = true;
                for (int i = 0; i < username.Length; i++)
                {
                    if (!char.IsLetterOrDigit(username[i]) && username[i] != '-' && username[i] != '_')
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    validUsernames.Add(username);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validUsernames));
        }
    }
}
