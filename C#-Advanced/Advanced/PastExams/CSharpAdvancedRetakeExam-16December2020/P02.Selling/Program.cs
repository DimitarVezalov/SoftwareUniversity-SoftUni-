using System;

namespace P02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int sellerRow = -1;
            int sellerCol = -1;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 'S')
                    {
                        sellerRow = row;
                        sellerCol = col;

                        matrix[row, col] = '-';
                    }
                }
            }

            int moneyColected = 0;
            bool isOutOfTheBakery = false;

            while (true)
            {
                int sellerNextRow = sellerRow;
                int sellerNextCol = sellerCol;

                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        sellerNextRow--;
                        break;
                    case "down":
                        sellerNextRow++;
                        break;
                    case "left":
                        sellerNextCol--;
                        break;
                    case "right":
                        sellerNextCol++;
                        break;
                }

                if (ValidateIndex(n, sellerNextRow, sellerNextCol))
                {
                    if (matrix[sellerNextRow, sellerNextCol] == 'O')
                    {
                        matrix[sellerNextRow, sellerNextCol] = '-';

                        for (int row = 0; row < n; row++)
                        {
                            for (int col = 0; col < n; col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    sellerNextRow = row;
                                    sellerNextCol = col;

                                    matrix[row, col] = '-';
                                }

                            }

                        }

                    }
                    else if (char.IsDigit(matrix[sellerNextRow, sellerNextCol]))
                    {
                        int currentMoney = int.Parse(matrix[sellerNextRow, sellerNextCol].ToString());

                        matrix[sellerNextRow, sellerNextCol] = '-';

                        moneyColected += currentMoney;
                    }

                }
                else
                {
                    isOutOfTheBakery = true;
                    break;
                }

                

                sellerRow = sellerNextRow;
                sellerCol = sellerNextCol;

                if (moneyColected >= 50)
                {
                    break;
                }

            }

            if (isOutOfTheBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
                matrix[sellerRow, sellerCol] = 'S';
            }

            Console.WriteLine($"Money: {moneyColected}");

            PrintMatrix(n, matrix);

        }

        private static bool ValidateIndex(int n, int row, int col)
        {
            return (row > -1 && row < n) && (col > -1 && col < n);
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
