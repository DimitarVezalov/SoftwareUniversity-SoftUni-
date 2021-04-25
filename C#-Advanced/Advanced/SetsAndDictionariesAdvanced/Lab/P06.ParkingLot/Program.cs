using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carPlates = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                string carNumber = cmdArgs[1];

                if (cmdType == "IN")
                {
                    carPlates.Add(carNumber);
                }
                else
                {
                    if (carPlates.Contains(carNumber))
                    {
                        carPlates.Remove(carNumber);
                    }
                }
            }

            string output = carPlates.Any() ? $"{string.Join(Environment.NewLine, carPlates)}"
                    : "Parking Lot is Empty";

            Console.WriteLine(output);
        }
    }
}
