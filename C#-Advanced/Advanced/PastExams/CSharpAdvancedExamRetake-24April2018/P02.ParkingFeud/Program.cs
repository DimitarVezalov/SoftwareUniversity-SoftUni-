using System;
using System.Linq;

namespace P02.ParkingFeud
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            char[] arr = text.Where(x => x != ' ').ToArray();

            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

           

            int rows = dimensions[0] + (dimensions[0] - 1);
            int cols = dimensions[1] + 2;

            string[,] matrix = CreateParking(rows, cols);

            bool IsParkedSuccessfully = false;

            //int[] entrances =

            while (true)
            {
                int samEntrance = int.Parse(Console.ReadLine());

                
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static string[,] CreateParking(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            int asciiCode = 'A';
            int rowCounter = 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row % 2 == 0 && (col != 0 && col != cols - 1))
                    {
                        matrix[row, col] = $"{(char)asciiCode}" + $"{rowCounter}";
                        asciiCode++;

                    }
                    else
                    {
                        matrix[row, col] = " -";
                    }
                }

                if (row % 2 == 0)
                {
                    rowCounter++;
                }

                asciiCode = 'A';
            }

            return matrix;
        }
    }
}
