using System;

namespace P02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int beeRow = -1;
            int beeCol = -1;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (currentRow[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            matrix[beeRow, beeCol] = '.';

            int polinatedFlowers = 0;
            bool isLost = false;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int beeNextRow = beeRow;
                int beeNextCol = beeCol;

                switch (command)
                {
                    case "up":
                        beeNextRow--;
                        break;
                    case "down":
                        beeNextRow++;
                        break;
                    case "left":
                        beeNextCol--;
                        break;
                    case "right":
                        beeNextCol++;
                        break;
                }

                if (!ValidateTerritory(n, beeNextRow, beeNextCol))
                {
                    isLost = true;
                    break;
                }
                else
                {
                    if (matrix[beeNextRow, beeNextCol] == 'f')
                    {
                        polinatedFlowers++;
                        matrix[beeNextRow, beeNextCol] = '.';
                    }
                    else if (matrix[beeNextRow, beeNextCol] == 'O')
                    {
                        matrix[beeNextRow, beeNextCol] = '.';

                        switch (command)
                        {
                            case "up":
                                beeNextRow--;
                                break;
                            case "down":
                                beeNextRow++;
                                break;
                            case "left":
                                beeNextCol--;
                                break;
                            case "right":
                                beeNextCol++;
                                break;
                        }

                        if (matrix[beeNextRow, beeNextCol] == 'f')
                        {
                            polinatedFlowers++;
                            matrix[beeNextRow, beeNextCol] = '.';
                        }
                    }
                }

                beeRow = beeNextRow;
                beeCol = beeNextCol;
            }

            if (isLost)
            {
                Console.WriteLine("The bee got lost!");
            }
            else
            {
                matrix[beeRow, beeCol] = 'B';
            }

            if (polinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }

            PrintMatrix(n, matrix);
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

        public static bool ValidateTerritory(int size, int row, int col)
        {
            if ((row < 0 || row >= size) || (col < 0 || col >= size))
            {
                return false;
            }

            return true;
        }
    }
}
