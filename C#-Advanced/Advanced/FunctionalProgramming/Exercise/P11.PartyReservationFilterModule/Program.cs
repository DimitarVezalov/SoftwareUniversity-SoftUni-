using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> filters = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] filterArgs = command
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (filterArgs[0] == "Add filter")
                {
                    filters.Add($"{filterArgs[1]} {filterArgs[2]}");
                }
                else
                {
                    filters.Remove($"{filterArgs[1]} {filterArgs[2]}");
                }
            }

            foreach (var filter in filters)
            {
                string[] cmdArgs = filter
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (cmdArgs[0] == "Starts")
                {
                    names = names.Where(x => !x.StartsWith(cmdArgs[2])).ToArray();
                }
                else if (cmdArgs[0] == "Ends")
                {
                    names = names.Where(x => !x.EndsWith(cmdArgs[2])).ToArray();
                }
                else if (cmdArgs[0] == "Length")
                {
                    names = names.Where(x => x.Length != int.Parse(cmdArgs[1])).ToArray();
                }
                else if (cmdArgs[0] == "Contains")
                {
                    names = names.Where(x => !x.Contains(cmdArgs[1])).ToArray();
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
