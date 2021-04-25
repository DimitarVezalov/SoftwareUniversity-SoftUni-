using System;
using System.Linq;

namespace P03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            FillMatrix(n, matrix);

            int diagonalSum = CalculateDiagonalSum(n, matrix);

            Console.WriteLine(diagonalSum);
        }

        private static void FillMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static int CalculateDiagonalSum(int n, int[,] matrix)
        {
            int sum = 0;
            int currRow = 0;
            int currCol = 0;

            for (int i = 0; i < n; i++)
            {
                sum += matrix[currRow, currCol];
                currRow++;
                currCol++;
            }

            return sum;
        }
    }
}
