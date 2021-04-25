using System;
using System.Linq;

namespace P03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = CreateMatrix(dimensions);

            int biggestSum = int.MinValue;

            int startRow = -1;

            int startCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = (matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]) +
                                (matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]) +
                                (matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2]);

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            PrintOutput(matrix, biggestSum, startRow, startCol);
        }

        private static void PrintOutput(int[,] matrix, int biggestSum, int startRow, int startCol)
        {
            Console.WriteLine($"Sum = {biggestSum}");

            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] CreateMatrix(int[] dimensions)
        {
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }
}
