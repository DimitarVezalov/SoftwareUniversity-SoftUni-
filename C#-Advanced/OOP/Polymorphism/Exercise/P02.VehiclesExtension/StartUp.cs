using System;
using System.Linq;

namespace P02.VehiclesExtension
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

            string[] busArgs = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .ToArray();

            Vehicle car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]), double.Parse(carArgs[3]));
            Vehicle truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(truckArgs[3]));
            Vehicle bus = new Bus(double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string commandType = commandArgs[0];
                string vehicle = commandArgs[1];

                try
                {
                    if (commandType == "Drive")
                    {
                        double distance = double.Parse(commandArgs[2]);

                        if (vehicle == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if(vehicle == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else
                        {
                            Console.WriteLine(bus.Drive(distance));
                        }

                    }
                    else if (commandType == "Refuel")
                    {
                        double amount = double.Parse(commandArgs[2]);

                        if (vehicle == "Car")
                        {
                            car.Refuel(amount);
                        }
                        else if(vehicle == "Truck")
                        {
                            truck.Refuel(amount);
                        }
                        else
                        {
                            bus.Refuel(amount);  
                        }

                    }
                    else if (commandType == "DriveEmpty")
                    {
                        Bus bus1 = bus as Bus;

                        Console.WriteLine(bus1.DriveEmpty(double.Parse(commandArgs[2])));
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);                  
                }

               
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
