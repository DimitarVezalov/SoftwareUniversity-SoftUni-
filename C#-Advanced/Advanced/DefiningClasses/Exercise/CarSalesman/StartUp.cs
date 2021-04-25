using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int engCount = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engCount; i++)
            {
                string[] engineArgs = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = engineArgs[0];
                int power = int.Parse(engineArgs[1]);

                Engine engine = null;

                if (engineArgs.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (engineArgs.Length == 3)
                {
                    int displacement;
                    
                    bool isParsed = int.TryParse(engineArgs[2], out displacement);

                    if (isParsed)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        string efficiency = engineArgs[2];
                        engine = new Engine(model, power, efficiency);
                    }

                }
                else if (engineArgs.Length == 4)
                {
                    int displacement = int.Parse(engineArgs[2]);
                    string efficiency = engineArgs[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }

                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carArgs[0];
                string engineModel = carArgs[1];

                Engine currEngine = engines.FirstOrDefault(e => e.Model == engineModel);

                Car car = null;

                if (carArgs.Length == 2)
                {
                    car = new Car(model, currEngine);
                }
                else if (carArgs.Length == 3)
                {
                    int weight;

                    bool isParsed = int.TryParse(carArgs[2], out weight);

                    if (isParsed)
                    {
                        car = new Car(model, currEngine, weight);
                    }
                    else
                    {
                        string color = carArgs[2];
                        car = new Car(model, currEngine, color);
                    }

                }
                else if (carArgs.Length == 4)
                {
                    int weight = int.Parse(carArgs[2]);
                    string color = carArgs[3];

                    car = new Car(model, currEngine, weight, color);
                }

                cars.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));

        }
    }
}
