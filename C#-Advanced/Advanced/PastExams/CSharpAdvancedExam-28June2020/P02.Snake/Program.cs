using System;

namespace P02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int snakeRow = -1;
            int snakeCol = -1;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (currentRow[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            int foodQuantity = 0;

            bool isGameOver = false;

            while (foodQuantity < 10)
            {
                string command = Console.ReadLine();

                int snakeNextRow = snakeRow;
                int snakeNextCol = snakeCol;

                matrix[snakeNextRow, snakeNextCol] = '.';

                switch (command)
                {
                    case "up":
                        snakeNextRow--;
                        break;
                    case "down":
                        snakeNextRow++;
                        break;
                    case "left":
                        snakeNextCol--;
                        break;
                    case "right":
                        snakeNextCol++;
                        break;
                }

                if ((snakeNextRow < 0 || snakeNextRow >= n) || (snakeNextCol < 0 || snakeNextCol >= n))
                {
                    isGameOver = true;
                    break;
                }

                if (matrix[snakeNextRow, snakeNextCol] == 'B')
                {
                    matrix[snakeNextRow, snakeNextCol] = '.';
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row, col] == 'B')
                            {
                                snakeNextRow = row;
                                snakeNextCol = col;
                            }
                        }
                    }
                }
                else if (matrix[snakeNextRow, snakeNextCol] == '*')
                {
                    foodQuantity++;
                }

                snakeRow = snakeNextRow;
                snakeCol = snakeNextCol;
               
            }

            if (isGameOver)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
                matrix[snakeRow, snakeCol] = 'S';
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");


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
