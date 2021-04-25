using System;

namespace P07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int knightsToRemove = 0;

            int knightToRemoveRow = -1;
            int knightToRemoveCol = -1;

            while (true)
            {
                int knightMostHits = 0;

                for (int row = 0; row < n; row++)
                {

                    for (int col = 0; col < n; col++)
                    {
                        int currentKnightHits = 0;

                        if (matrix[row, col] == 'K')
                        {
                            if (IsValidIndex(matrix, row - 2, col - 1))
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    currentKnightHits++;
                                }
                            }

                            if (IsValidIndex(matrix, row - 1, col - 2))
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    currentKnightHits++;
                                }
                            }

                            if (IsValidIndex(matrix, row - 2, col + 1))
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    currentKnightHits++;
                                }
                            }

                            if (IsValidIndex(matrix, row - 1, col + 2))
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    currentKnightHits++;
                                }
                            }

                            if (IsValidIndex(matrix, row + 2, col - 1))
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    currentKnightHits++;
                                }
                            }

                            if (IsValidIndex(matrix, row + 1, col - 2))
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    currentKnightHits++;
                                }
                            }

                            if (IsValidIndex(matrix, row + 2, col + 1))
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    currentKnightHits++;
                                }
                            }

                            if (IsValidIndex(matrix, row + 1, col + 2))
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    currentKnightHits++;
                                }
                            }

                        }

                        if (currentKnightHits > knightMostHits)
                        {
                            knightMostHits = currentKnightHits;
                            knightToRemoveRow = row;
                            knightToRemoveCol = col;
                        }

                    }

                }

                if (knightMostHits == 0)
                {
                    break;
                }
                else
                {
                    matrix[knightToRemoveRow, knightToRemoveCol] = '0';
                    knightsToRemove++;
                }
            }
            

            Console.WriteLine(knightsToRemove);
        }

        private static bool IsValidIndex(char[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1));
        }
    }
}
