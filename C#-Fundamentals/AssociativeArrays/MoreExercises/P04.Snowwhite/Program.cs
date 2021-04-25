using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dwarfs = new Dictionary<string, Dictionary<string, int>>();

            string command;
            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                string[] cmdArgs = command
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string dwarfName = cmdArgs[0];
                string hatColor = cmdArgs[1];
                int dwarfPhysics = int.Parse(cmdArgs[2]);

                if (!dwarfs.ContainsKey(hatColor))
                {
                    dwarfs[hatColor] = new Dictionary<string, int>();
                }

                if (!dwarfs[hatColor].ContainsKey(dwarfName))
                {
                    dwarfs[hatColor][dwarfName] = 0;
                }

                if (dwarfPhysics > dwarfs[hatColor][dwarfName])
                {
                    dwarfs[hatColor][dwarfName] = dwarfPhysics;
                }
            }

            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();

            foreach (var kvp in dwarfs.OrderByDescending(d => d.Value.Count))
            {
                foreach (var item in kvp.Value)
                {
                    sortedDwarfs.Add($"({kvp.Key}) {item.Key} <-> ", item.Value);
                }
            }

            foreach (var kvp in sortedDwarfs.OrderByDescending(d => d.Value))
            {
                Console.WriteLine($"{kvp.Key}{kvp.Value}");
            }
        }
    }
}
