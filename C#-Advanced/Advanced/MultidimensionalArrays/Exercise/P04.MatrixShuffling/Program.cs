using System;
using System.Linq;

namespace P04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            string[,] matrix = CreateMatrix(dimensions);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                bool isValidateInput = ValidateInput(cmdArgs);

                if (isValidateInput)
                {
                    int firstRow = int.Parse(cmdArgs[1]);
                    int firstCol = int.Parse(cmdArgs[2]);

                    int secondRow = int.Parse(cmdArgs[3]);
                    int secondCol = int.Parse(cmdArgs[4]);

                    bool areValidIndexes = ValidateIndexes(matrix, firstRow, firstCol, secondRow, secondCol);

                    if (areValidIndexes)
                    {
                        string temp = matrix[firstRow, firstCol];
                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = temp;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool ValidateIndexes(string[,] matrix, int firstRow, int firstCol, int secondRow, int secondCol)
        {
            bool isFirstCellValid = (firstRow >= 0 && firstRow < matrix.GetLength(0)) &&
                                    (firstCol >= 0 && firstCol < matrix.GetLength(1));

            bool isSecondCellValid = (secondRow >= 0 && secondRow < matrix.GetLength(0)) &&
                                    (secondCol >= 0 && secondCol < matrix.GetLength(1));

            return isFirstCellValid && isSecondCellValid;
        }

        private static bool ValidateInput(string[] cmdArgs)
        {
            return (cmdArgs[0] == "swap") && (cmdArgs.Length == 5);
        }

        private static string[,] CreateMatrix(int[] dimensions)
        {
            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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
