using System;
using System.Linq;

namespace P06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            byte rows = byte.Parse(Console.ReadLine());

            double[][] matrix = CreateMatrix(rows);

            AnalyzeMatrix(matrix);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (!IsValidIndex(matrix,row,col))
                {
                    continue;
                }               

                if (type == "Add")
                {
                    matrix[row][col] += value;
                }
                else
                {
                    matrix[row][col] -= value;
                }

            }

            PrintMatrix(rows, matrix);
        }

        private static bool IsValidIndex(double [][] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.Length) && (col >= 0 && col < matrix[row].Length);
        }

        private static void PrintMatrix(int rows, double[][] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static void AnalyzeMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row]
                        .Select(x => x * 2)
                        .ToArray();

                    matrix[row + 1] = matrix[row + 1]
                        .Select(x => x * 2)
                        .ToArray();
                }
                else
                {
                    matrix[row] = matrix[row]
                     .Select(x => x / 2)
                     .ToArray();

                    matrix[row + 1] = matrix[row + 1]
                        .Select(x => x / 2)
                        .ToArray();
                }

            }
        }

        private static double[][] CreateMatrix(int rows)
        {
            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            return matrix;
        }
    }
}
