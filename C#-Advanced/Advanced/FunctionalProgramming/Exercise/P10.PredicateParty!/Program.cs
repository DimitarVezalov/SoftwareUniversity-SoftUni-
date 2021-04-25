using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<List<string>, string, string, List<string>> func = ( list, command, substring) =>
            {
                List<string> namesToProcess = new List<string>();

                if (command == "StartsWith")
                {
                    namesToProcess = list.Where(x => x.StartsWith(substring)).ToList();
                }
                else if (command == "EndsWith")
                {
                    namesToProcess = list.Where(x => x.EndsWith(substring)).ToList();
                }
                else if (command == "Length")
                {
                    namesToProcess = list.Where(x => x.Length == int.Parse(substring)).ToList();
                }

                return namesToProcess;
            };

            Action<List<string>, List<string>, string> action = (mainList, namesToProcess, command) =>
           {
               if (command == "Remove")
               {
                   foreach (var name in namesToProcess)
                   {
                       mainList.Remove(name);
                   }
               }
               else if (command == "Double")
               {
                   foreach (var name in namesToProcess)
                   {
                       mainList.Insert(mainList.IndexOf(name), name);
                   }
               }
           };

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                string cmdName = cmdArgs[1];
                string argument = cmdArgs[2];

                action(names, func(names, cmdName, argument), cmdType);
            }

            if (names.Any())
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
