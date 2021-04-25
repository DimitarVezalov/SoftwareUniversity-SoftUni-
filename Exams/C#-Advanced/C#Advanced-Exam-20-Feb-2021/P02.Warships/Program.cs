using System;
using System.Linq;

namespace P02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] allCoordinates = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            char[,] matrix = new char[n, n];

            int playerOneShipsCount = 0;
            int playerTwoShipsCount = 0;

            int totalShipsDestroyed = 0;

            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().Where(x => x != ' ').ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == '<')
                    {
                        playerOneShipsCount++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        playerTwoShipsCount++;
                    }
                }
            }

            for (int i = 0; i < allCoordinates.Length; i++)
            {
                int[] currCoordinates = allCoordinates[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currRow = currCoordinates[0];
                int currCol = currCoordinates[1];

                if (ValidateCoordinates(currRow, currCol, n))
                {
                    if (matrix[currRow, currCol] == '>')
                    {
                        playerTwoShipsCount--;
                        matrix[currRow, currCol] = 'X';
                        totalShipsDestroyed++;
                    }
                    else if (matrix[currRow, currCol] == '<')
                    {
                        playerOneShipsCount--;
                        matrix[currRow, currCol] = 'X';
                        totalShipsDestroyed++;
                    }
                    else if (matrix[currRow, currCol] == '#')
                    {
                        matrix[currRow, currCol] = 'X';

                        if (ValidateCoordinates(currRow - 1, currCol, n))
                        {
                            if (matrix[currRow - 1, currCol] == '<')
                            {
                                playerOneShipsCount--;
                                totalShipsDestroyed++;
                                
                            }
                            else if (matrix[currRow - 1, currCol] == '>')
                            {
                                playerTwoShipsCount--;
                                totalShipsDestroyed++;
                               
                            }

                            matrix[currRow - 1, currCol] = 'X';
                        }
                        if (ValidateCoordinates(currRow - 1, currCol + 1, n))
                        {
                            if (matrix[currRow - 1, currCol + 1] == '<')
                            {
                                playerOneShipsCount--;
                                totalShipsDestroyed++;
                                
                            }
                            else if (matrix[currRow - 1, currCol + 1] == '>')
                            {
                                playerTwoShipsCount--;
                                totalShipsDestroyed++;
                                
                            }

                            matrix[currRow - 1, currCol + 1] = 'X';
                        }
                        if (ValidateCoordinates(currRow, currCol + 1, n))
                        {
                            if (matrix[currRow, currCol + 1] == '<')
                            {
                                playerOneShipsCount--;
                                totalShipsDestroyed++;
                               
                            }
                            else if (matrix[currRow, currCol + 1] == '>')
                            {
                                playerTwoShipsCount--;
                                totalShipsDestroyed++;
                                
                            }

                            matrix[currRow, currCol + 1] = 'X';
                        }
                        if (ValidateCoordinates(currRow + 1, currCol + 1, n))
                        {
                            if (matrix[currRow + 1, currCol + 1] == '<')
                            {
                                playerOneShipsCount--;
                                totalShipsDestroyed++;
                                
                            }
                            else if (matrix[currRow + 1, currCol + 1] == '>')
                            {
                                playerTwoShipsCount--;
                                totalShipsDestroyed++;
                                
                            }

                            matrix[currRow + 1, currCol + 1] = 'X';
                        }
                        if (ValidateCoordinates(currRow + 1, currCol, n))
                        {
                            if (matrix[currRow + 1, currCol] == '<')
                            {
                                playerOneShipsCount--;
                                totalShipsDestroyed++;
                                
                            }
                            else if (matrix[currRow + 1, currCol] == '>')
                            {
                                playerTwoShipsCount--;
                                totalShipsDestroyed++;
                                
                            }

                            matrix[currRow + 1, currCol] = 'X';
                        }
                        if (ValidateCoordinates(currRow + 1, currCol - 1, n))
                        {
                            if (matrix[currRow + 1, currCol - 1] == '<')
                            {
                                playerOneShipsCount--;
                                totalShipsDestroyed++;
                               
                            }
                            else if (matrix[currRow + 1, currCol - 1] == '>')
                            {
                                playerTwoShipsCount--;
                                totalShipsDestroyed++;
                               
                            }

                            matrix[currRow + 1, currCol - 1] = 'X';
                        }
                        if (ValidateCoordinates(currRow, currCol - 1, n))
                        {
                            if (matrix[currRow, currCol - 1] == '<')
                            {
                                playerOneShipsCount--;
                                totalShipsDestroyed++;
                                
                            }
                            else if (matrix[currRow, currCol - 1] == '>')
                            {
                                playerTwoShipsCount--;
                                totalShipsDestroyed++;
                               
                            }

                            matrix[currRow, currCol - 1] = 'X';
                        }
                        if (ValidateCoordinates(currRow - 1, currCol - 1, n))
                        {
                            if (matrix[currRow - 1, currCol - 1] == '<')
                            {
                                playerOneShipsCount--;
                                totalShipsDestroyed++;
                                
                            }
                            else if (matrix[currRow - 1, currCol - 1] == '>')
                            {
                                playerTwoShipsCount--;
                                totalShipsDestroyed++;
                                
                            }

                            matrix[currRow - 1, currCol - 1] = 'X';
                        }
                    }
                }

                if (playerOneShipsCount == 0 || playerTwoShipsCount == 0)
                {
                    break;
                }

            }

            if (playerOneShipsCount > 0 && playerTwoShipsCount > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShipsCount} ships left. Player Two has {playerTwoShipsCount} ships left.");
            }
            else if (playerTwoShipsCount == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (playerOneShipsCount == 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
            }

        }

        private static void PrintMatrix(int n, char[,] matrix)
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

        private static bool ValidateCoordinates(int row, int col, int size)
        {
            return (row > -1 && row < size) && (col > -1 && col < size);
        }
    }
}
