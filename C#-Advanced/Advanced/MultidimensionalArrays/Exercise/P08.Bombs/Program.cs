using System;
using System.Linq;

namespace P08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string[] bombCoordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                int[] bombArgs = bombCoordinates[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int bombRow = bombArgs[0];
                int bombCol = bombArgs[1];

                int power = matrix[bombRow, bombCol];

                if (power > 0)
                {
                    if (IsValidIndex(matrix, bombRow - 1, bombCol - 1))
                    {
                        if (matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol - 1] -= power;
                        }
                    }

                    if (IsValidIndex(matrix, bombRow - 1, bombCol))
                    {
                        if (matrix[bombRow - 1, bombCol] > 0)
                        {
                            matrix[bombRow - 1, bombCol] -= power;
                        }
                    }

                    if (IsValidIndex(matrix, bombRow - 1, bombCol + 1))
                    {
                        if (matrix[bombRow - 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol + 1] -= power;
                        }
                    }

                    if (IsValidIndex(matrix, bombRow, bombCol + 1))
                    {
                        if (matrix[bombRow, bombCol + 1] > 0)
                        {
                            matrix[bombRow, bombCol + 1] -= power;
                        }
                    }

                    if (IsValidIndex(matrix, bombRow + 1, bombCol + 1))
                    {
                        if (matrix[bombRow + 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol + 1] -= power;
                        }
                    }

                    if (IsValidIndex(matrix, bombRow + 1, bombCol))
                    {
                        if (matrix[bombRow + 1, bombCol] > 0)
                        {
                            matrix[bombRow + 1, bombCol] -= power;
                        }
                    }

                    if (IsValidIndex(matrix, bombRow + 1, bombCol - 1))
                    {
                        if (matrix[bombRow + 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol - 1] -= power;
                        }
                    }

                    if (IsValidIndex(matrix, bombRow, bombCol - 1))
                    {
                        if (matrix[bombRow, bombCol - 1] > 0)
                        {
                            matrix[bombRow, bombCol - 1] -= power;
                        }
                    }

                    matrix[bombRow, bombCol] = 0;
                }
 
            }

            int sum = 0;
            int aliveCells = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}\nSum: {sum}");

            PrintMatrix(n, matrix);

        }

        private static void PrintMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValidIndex(int[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1));
        }
    }
}
