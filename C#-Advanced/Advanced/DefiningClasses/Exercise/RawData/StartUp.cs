using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
 
            for (int i = 0; i < count; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carArgs[0];

                int engineSpeed = int.Parse(carArgs[1]);
                int enginePower = int.Parse(carArgs[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carArgs[3]);
                string cargoType = carArgs[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4];
                int counter = 0;
                for (int j = 5; j < carArgs.Length; j += 2)
                {
                    double pressure = double.Parse(carArgs[j]);
                    int age = int.Parse(carArgs[j + 1]);

                    Tire tire = new Tire(pressure, age);
                    tires[counter] = tire;
                    counter++;
                }

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);

            }

            string cargoArgument = Console.ReadLine();

            if (cargoArgument == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars
                                                        .Where(c => c.Cargo.Type == cargoArgument &&
                                                        c.Tires.Any(t => t.Pressure < 1))
                                                        .Select(c => c.Model)));
            }
            else if (cargoArgument == "flamable")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars
                                                        .Where(c => c.Cargo.Type == cargoArgument &&
                                                        c.Engine.Power > 250)
                                                        .Select(c => c.Model)));
            }
        }
    }
}
