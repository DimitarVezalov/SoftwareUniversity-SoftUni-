    using System;

    namespace P02.Re_Volt
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());

                int commandsCount = int.Parse(Console.ReadLine());

                char[,] matrix = CreateMatrix(n);

                int playerRow = -1;
                int playerCol = -1;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'f')
                        {
                            playerRow = row;
                            playerCol = col;
                        }
                    }
                }

                matrix[playerRow, playerCol] = '-';

                bool hasWon = false;

                for (int i = 0; i < commandsCount; i++)
                {
                    string command = Console.ReadLine();

                    int playerNextRow = playerRow;
                    int playerNextCol = playerCol;

                    switch (command)
                    {
                        case "up":
                            playerNextRow--;

                            if (playerNextRow == -1)
                            {
                                playerNextRow = n - 1;
                            }

                            if (matrix[playerNextRow, playerNextCol] == 'B')
                            {
                                playerNextRow--;

                                if (playerNextRow == -1)
                                {
                                    playerNextRow = n - 1;
                                }
                            }

                            break;
                        case "down":
                            playerNextRow++;

                            if (playerNextRow == n)
                            {
                                playerNextRow = 0;
                            }

                            if (matrix[playerNextRow, playerNextCol] == 'B')
                            {
                                playerNextRow++;

                                if (playerNextRow == n)
                                {
                                    playerNextRow = 0;
                                }
                            }

                            break;
                        case "left":
                            playerNextCol--;

                            if (playerNextCol == -1)
                            {
                                playerNextCol = n - 1;
                            }

                            if (matrix[playerNextRow, playerNextCol] == 'B')
                            {
                                playerNextCol--;

                                if (playerNextCol == -1)
                                {
                                    playerNextCol = n - 1;
                                }
                            }

                            break;
                        case "right":
                            playerNextCol++;

                            if (playerNextCol == n)
                            {
                                playerNextCol = 0;
                            }

                            if (matrix[playerNextRow, playerNextCol] == 'B')
                            {
                                playerNextCol++;

                                if (playerNextCol == n)
                                {
                                    playerNextCol = 0;
                                }
                            }

                            break;
                    }

                    if (matrix[playerNextRow, playerNextCol] == 'T')
                    {
                        playerNextRow = playerRow;
                        playerNextCol = playerCol;
                    }


                    playerRow = playerNextRow;
                    playerCol = playerNextCol;

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        hasWon = true;
                        break;
                    }

                }

                matrix[playerRow, playerCol] = 'f';

                if (hasWon)
                {
                    Console.WriteLine("Player won!");
               
                }
                else
                {
                    Console.WriteLine("Player lost!");

                }

                PrintMatrix(n, matrix);
            }

        

            private static char[,] CreateMatrix(int n)
            {
                char[,] matrix = new char[n, n];

                for (int row = 0; row < n; row++)
                {
                    string currentRow = Console.ReadLine();

                    for (int col = 0; col < n; col++)
                    {
                        matrix[row, col] = currentRow[col];
                    }
                }

                return matrix;
            }

            private static void PrintMatrix(int n, char[,] matrix)
            {
                for (int row = 0; row < n; row++)
                {

                    for (int col = 0; col < n; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
