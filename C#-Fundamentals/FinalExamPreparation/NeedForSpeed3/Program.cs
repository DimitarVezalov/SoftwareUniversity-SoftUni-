using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeed3
{
    public class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            this.Name = name;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public string Name { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }
       
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                AddCars(cars);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = cmdArgs[0];
                string name = cmdArgs[1];

                if (type == "Drive")
                {                   
                    int distance = int.Parse(cmdArgs[2]);
                    int fuel = int.Parse(cmdArgs[3]);
                    Drive(cars, name, distance, fuel);
                }
                else if (type == "Refuel")
                {                   
                    int fuel = int.Parse(cmdArgs[2]);
                    Refuel(cars, name , fuel);
                }
                else if (type == "Revert")
                {                   
                    int kilometers = int.Parse(cmdArgs[2]);
                    Revert(cars, name, kilometers);
                }
            }

            cars = cars.OrderByDescending(c => c.Mileage).ThenBy(c => c.Name).ToList();

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }

        }

        private static void AddCars(List<Car> cars)
        {
            string[] carArgs = Console.ReadLine()
                                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            string name = carArgs[0];
            int mileage = int.Parse(carArgs[1]);
            int fuel = int.Parse(carArgs[2]);

            Car car = new Car(name, mileage, fuel);
            cars.Add(car);
        }

        private static void Revert(List<Car> cars, string name, int kilometers)
        {
            Car car = cars.FirstOrDefault(c => c.Name == name);

            car.Mileage -= kilometers;

            if (car.Mileage >= 10000)
            {
                Console.WriteLine($"{name} mileage decreased by {kilometers} kilometers");
            }
            else
            {
                car.Mileage = 10000;
            }
        }

        public static void Refuel(List<Car> cars, string name, int fuel)
        {
            Car car = cars.FirstOrDefault(c => c.Name == name);

            int fuelBeforeRefuel = car.Fuel;
            car.Fuel += fuel;

            int refueledFuel = 0;
            if (car.Fuel > 75)
            {
                car.Fuel = 75;
                refueledFuel = 75 - fuelBeforeRefuel;
            }
            else
            {
                refueledFuel = fuel;
            }

            Console.WriteLine($"{name} refueled with {refueledFuel} liters");
        }

        public static void Drive(List<Car> cars, string name, int distance, int fuel)
        {
            Car car = cars.FirstOrDefault(c => c.Name == name);

            string output = "";

            if (fuel > car.Fuel)
            {
                output = "Not enough fuel to make that ride";
            }
            else
            {
                car.Fuel -= fuel;
                car.Mileage += distance;
                output = $"{name} driven for {distance} kilometers. {fuel} liters of fuel consumed.";
            }

            Console.WriteLine(output);

            if (car.Mileage >= 100000)
            {
                Console.WriteLine($"Time to sell the {name}!");
                cars.Remove(car);
            }
        }


    }
}
