using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>(); 

            string tiresInput;
            while ((tiresInput = Console.ReadLine()) != "No more tires")
            {
                string[] tiresArgs = tiresInput
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Tire[] currTires = new Tire[4];

                int index = 0;
                for (int i = 0; i < tiresArgs.Length; i += 2)
                {
                    int year = int.Parse(tiresArgs[i]);
                    double pressure = double.Parse(tiresArgs[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    currTires[index] = tire;
                    index++;
                }

                tires.Add(currTires);
            }

            List<Engine> engines = new List<Engine>();

            string engineInput;
            while ((engineInput = Console.ReadLine()) != "Engines done")
            {
                string[] engineArgs = engineInput
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int horsePower = int.Parse(engineArgs[0]);
                double CubicCapacity = double.Parse(engineArgs[1]);

                Engine engine = new Engine(horsePower, CubicCapacity);

                engines.Add(engine);    
            }

            List<Car> cars = new List<Car>();

            string carInput;
            while ((carInput = Console.ReadLine()) != "Show special")
            {
                string[] carArgs = carInput
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string make = carArgs[0];
                string model = carArgs[1];
                int year = int.Parse(carArgs[2]);
                double fuelQuantity = double.Parse(carArgs[3]);
                double fuelConsumption = double.Parse(carArgs[4]);
                Engine engine = engines[int.Parse(carArgs[5])];
                Tire[] currTires = tires[int.Parse(carArgs[6])];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, currTires);

                cars.Add(car);
            }

            List<Car> specialCars = cars
                .Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330
                && (c.Tires.Select(t => t.Pressure).Sum() > 9 && c.Tires.Select(t => t.Pressure).Sum() < 10))
                .ToList();

            foreach (Car c in specialCars)
            {
                c.Drive(20);
            }

            foreach (Car c in specialCars)
            {
                StringBuilder sb = new StringBuilder();

                sb.
                     AppendLine($"Make: {c.Make}")
                    .AppendLine($"Model: {c.Model}")
                    .AppendLine($"Year: {c.Year}")
                    .AppendLine($"HorsePowers: {c.Engine.HorsePower}")
                    .AppendLine($"FuelQuantity: {c.FuelQuantity}");

                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
