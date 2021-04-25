using System;
using System.Linq;

namespace P01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] truckArgs = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .ToArray();

            Vehicle car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]));
            Vehicle truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]));

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string commandType = commandArgs[0];
                string vehicle = commandArgs[1];

                if (commandType == "Drive")
                {
                    double distance = double.Parse(commandArgs[2]);

                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }

                }
                else if (commandType == "Refuel")
                {
                    double amount = double.Parse(commandArgs[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else
                    {
                        truck.Refuel(amount);
                    }

                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
