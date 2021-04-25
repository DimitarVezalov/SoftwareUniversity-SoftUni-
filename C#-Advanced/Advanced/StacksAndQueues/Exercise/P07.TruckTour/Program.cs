using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace P07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> pumps = new Queue<string>();

            int pumpsCount = int.Parse(Console.ReadLine());

            for (int a = 0; a < pumpsCount; a++)
            {
                string pumpArgs = Console.ReadLine();
                pumps.Enqueue(pumpArgs);
            }

            int startingPumpIndex = 0;

            while (true)
            {
                int truckFuel = 0;
                bool isFound = true;

                foreach (var pump in pumps)
                {
                    string[] fuelArgs = pump.Split(" ").ToArray();
                    int fuelAmount = int.Parse(fuelArgs[0]);
                    int distance = int.Parse(fuelArgs[1]);

                    truckFuel += fuelAmount;

                    if (truckFuel < distance)
                    {
                        isFound = false;
                        break;
                    }

                    truckFuel -= distance;
                }

                if (isFound)
                {
                    break;
                }

                pumps.Enqueue(pumps.Dequeue());
                startingPumpIndex++;
            }

            Console.WriteLine(startingPumpIndex);
        }
    }
}