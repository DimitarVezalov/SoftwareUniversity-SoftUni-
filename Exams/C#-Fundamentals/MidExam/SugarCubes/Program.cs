using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SugarCubes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sugarCubes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Mort")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                int value = int.Parse(cmdArgs[1]);

                if (cmdType == "Add")
                {
                    sugarCubes.Add(value);
                }
                else if (cmdType == "Remove")
                {
                    sugarCubes.Remove(value);
                }
                else if (cmdType == "Replace")
                {
                    int replacement = int.Parse(cmdArgs[2]);
                    sugarCubes[sugarCubes.IndexOf(value)] = replacement;

                }
                else if (cmdType == "Collapse")
                {
                    sugarCubes = sugarCubes.Where(x => x >= value).ToList();
                }

            }

            Console.WriteLine(string.Join(" ", sugarCubes));

        }
    }
}
