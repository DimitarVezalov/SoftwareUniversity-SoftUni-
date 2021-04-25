using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input;
            while ((input = Console.ReadLine()) != "find")
            {
                int numbersIndex = 0;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    if (numbersIndex == numbers.Length)
                    {
                        numbersIndex = 0;
                    }

                    int asciiCode = input[i] - numbers[numbersIndex];
                    char currentChar = (char)asciiCode;
                    sb.Append(currentChar);

                    numbersIndex++;
                }

                string decryptedMsg = sb.ToString();

                string[] treasureTypeArgs = decryptedMsg.Split('&');
                string treasureType = treasureTypeArgs[1];

                int coordinatesStartIndex = decryptedMsg.IndexOf('<') + 1;
                int coordinatesEndIndex = decryptedMsg.IndexOf('>');
                string coordinates = decryptedMsg
                    .Substring(coordinatesStartIndex, coordinatesEndIndex - coordinatesStartIndex);

                Console.WriteLine($"Found {treasureType} at {coordinates}");
            }

        }
    }
}