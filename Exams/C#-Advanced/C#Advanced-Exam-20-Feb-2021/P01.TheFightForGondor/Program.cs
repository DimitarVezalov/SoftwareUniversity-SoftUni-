using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int orcWaves = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            bool isDefenseDestroyed = false;

            Stack<int> remainingOrcs = new Stack<int>();

            for (int i = 1; i <= orcWaves; i++)
            {
                int[] orcsArr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Stack<int> orcs = new Stack<int>(orcsArr);

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Add(newPlate);
                }

                while (orcs.Any() && plates.Any())
                {
                    if (orcs.Peek() > plates[0])
                    {
                        orcs.Push(orcs.Pop() - plates[0]);
                        plates.RemoveAt(0);
                    }
                    else if (plates[0] > orcs.Peek())
                    {
                        plates[0] -= orcs.Pop();
                    }
                    else if (plates[0] == orcs.Peek())
                    {
                        plates.RemoveAt(0);
                        orcs.Pop();
                    }
                }

                if (!plates.Any())
                {
                    isDefenseDestroyed = true;
                    remainingOrcs = orcs;
                    break;
                }
            }

            if (isDefenseDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", remainingOrcs)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: { string.Join(", ", plates)}");
            }

        }
    }
}
