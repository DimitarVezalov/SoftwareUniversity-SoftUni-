using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;

                        matrix[row, col] = '.';
                    }
                }
            }

            string directions = Console.ReadLine();

            bool isDead = false;

            for (int i = 0; i < directions.Length; i++)
            {
                char direction = directions[i];

                int playerNewRow = playerRow;
                int playerNewCol = playerCol;

                switch (direction)
                {
                    case 'U':
                        playerNewRow--;
                        break;
                    case 'D':
                        playerNewRow++;
                        break;
                    case 'L':
                        playerNewCol--;
                        break;
                    case 'R':
                        playerNewCol++;
                        break;
                }

                if (!IsValidIndex(matrix, playerNewRow, playerNewCol))
                {
                    break;
                }

                if (matrix[playerNewRow, playerNewCol] == 'B')
                {
                    isDead = true;
                    playerRow = playerNewRow;
                    playerCol = playerNewCol;
                    break;
                }

                playerRow = playerNewRow;
                playerCol = playerNewCol;

                List<int> bunniesCoordinates = GetBunniesCoordinates(matrix);

                for (int j = 0; j < bunniesCoordinates.Count; j+=2)
                {
                    int bunnyRow = bunniesCoordinates[j];
                    int bunnyCol = bunniesCoordinates[j + 1];

                    if (IsValidIndex(matrix, bunnyRow, bunnyCol - 1))
                    {
                        if (bunnyRow == playerRow && bunnyCol - 1 == playerCol)
                        {
                            isDead = true;
                            break;
                        }
                    }

                    if (IsValidIndex(matrix, bunnyRow - 1, bunnyCol))
                    {
                        if (bunnyRow - 1 == playerRow && bunnyCol == playerCol)
                        {
                            isDead = true;
                            break;
                        }
                    }

                    if (IsValidIndex(matrix, bunnyRow, bunnyCol + 1))
                    {
                        if (bunnyRow == playerRow && bunnyCol + 1 == playerCol)
                        {
                            isDead = true;
                            break;
                        }
                    }

                    if (IsValidIndex(matrix, bunnyRow + 1, bunnyCol))
                    {
                        if (bunnyRow + 1 == playerRow && bunnyCol == playerCol)
                        {
                            isDead = true;
                            break;
                        }
                    }

                }

                if (isDead)
                {
                    break;
                }

                SpreadBunnies(matrix, bunniesCoordinates);
            }

            SpreadBunnies(matrix, GetBunniesCoordinates(matrix));
            PrintMatrix(matrix);

            Console.WriteLine(isDead ? $"dead: {playerRow} {playerCol}" : $"won: {playerRow} {playerCol}");

            
        }

        private static void SpreadBunnies(char[,] matrix, List<int> coordinates)
        {
            for (int i = 0; i < coordinates.Count; i+=2)
            {
                int bunnyRow = coordinates[i];
                int bunnyCol = coordinates[i + 1];

                if (IsValidIndex(matrix, bunnyRow, bunnyCol - 1))
                {
                    matrix[bunnyRow, bunnyCol - 1] = 'B';
                }

                if (IsValidIndex(matrix, bunnyRow - 1, bunnyCol))
                {
                    matrix[bunnyRow - 1, bunnyCol] = 'B';
                }

                if (IsValidIndex(matrix, bunnyRow, bunnyCol + 1))
                {
                    matrix[bunnyRow, bunnyCol + 1] = 'B';
                }

                if (IsValidIndex(matrix, bunnyRow + 1, bunnyCol))
                {
                    matrix[bunnyRow + 1, bunnyCol] = 'B';
                }
            }
        }

        private static List<int> GetBunniesCoordinates(char[,] matrix)
        {
            List<int> coordinates = new List<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        coordinates.Add(row);
                        coordinates.Add(col);
                    }
                }
            }

            return coordinates;
        }

        private static bool IsValidIndex(char[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1));
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
