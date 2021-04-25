using System;
using System.Linq;

namespace P05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            int[,] matrix = new int[rows, cols];

            FillMatrix(rows, cols, matrix);

            int biggestSum = 0;
            int currRow = -1;
            int currCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] +
                                     matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        currRow = row;
                        currCol = col;
                    }
                }
            }


            PrintResult(matrix, biggestSum, currRow, currCol);
        }

        private static void FillMatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static void PrintResult(int[,] matrix, int biggestSum, int currRow, int currCol)
        {
            for (int row = currRow; row < currRow + 2; row++)
            {
                for (int col = currCol; col < currCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(biggestSum);
        }
    }
}
