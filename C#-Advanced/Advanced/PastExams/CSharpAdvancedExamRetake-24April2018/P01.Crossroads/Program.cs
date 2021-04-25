using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.Crossroads
{
    public class Program
    {
        private static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            bool isHit = false;

            string hitCar = "";
            char hitIndex = ' ';

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    int curGreenLight = greenLightDuration;

                    while (curGreenLight > 0 && cars.Any())
                    {
                        string currCar = cars.Dequeue();

                        int carLength = currCar.Length;

                        if (carLength <= curGreenLight)
                        {
                            curGreenLight -= carLength;
                            carsPassed++;
                            continue;
                        }

                        carLength -= curGreenLight;
                        curGreenLight = 0;

                        if (carLength <= freeWindowDuration)
                        {
                            carsPassed++;
                            continue;
                        }

                        isHit = true;
                        hitCar = currCar;
                        int charsLeft = carLength - freeWindowDuration;
                        hitIndex = currCar[currCar.Length - charsLeft];
                    }

                }
                else
                {
                    cars.Enqueue(command);
                }

                if (isHit)
                {
                    break;
                }
            }

            if (isHit)
            {
                Console.WriteLine($"A crash happened!\n{hitCar} was hit at {hitIndex }.");
            }
            else
            {
                Console.WriteLine($"Everyone is safe.\n{carsPassed} total cars passed the crossroads.");
            }
        }
    }
}
