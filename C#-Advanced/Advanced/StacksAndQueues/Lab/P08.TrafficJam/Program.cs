using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int carsPassed = 0;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (cars.Any())
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            carsPassed++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
