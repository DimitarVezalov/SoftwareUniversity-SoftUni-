using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            int currentSnakeIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (currentSnakeIndex >= snake.Length)
                        {
                            currentSnakeIndex = 0;
                        }

                        matrix[row, col] = snake[currentSnakeIndex];

                        currentSnakeIndex++;
                    }

                }
                else
                {                   
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currentSnakeIndex >= snake.Length)
                        {
                            currentSnakeIndex = 0;
                        }

                        matrix[row, col] = snake[currentSnakeIndex];
                      
                        currentSnakeIndex++;
                    }

                }
            
            }

            PrintMatrix(rows, cols, matrix);
        }

        private static void PrintMatrix(int rows, int cols, char[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
