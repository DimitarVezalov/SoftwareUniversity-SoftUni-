using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> coordinates = new List<int>();

            int size = dimensions[0];

            int[,] matrix = new int[size, size];

            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] currentFlowerCoordinates = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int flowerRow = currentFlowerCoordinates[0];
                int flowerCol = currentFlowerCoordinates[1];

                if (ValidateIndexes(size, flowerRow, flowerCol))
                {
                    coordinates.AddRange(currentFlowerCoordinates);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            for (int i = 0; i < coordinates.Count; i += 2)
            {
                int flowerRow = coordinates[i];
                int flowerCol = coordinates[i + 1];

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (row == flowerRow || col == flowerCol)
                        {
                            matrix[row, col] += 1;
                        }
                    }
                }


            }

            PrintMatrix(size, matrix);
        }

        public static bool ValidateIndexes(int size, int row, int col)
        {
            return (row > -1 && row < size) && (col > -1 && col < size);
        }

        private static void PrintMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
