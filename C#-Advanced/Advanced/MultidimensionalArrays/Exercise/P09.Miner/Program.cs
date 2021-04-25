using System;
using System.Linq;

namespace P09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] directions = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[,] field = new string[n, n];

            int minerRow = -1;
            int minerCol = -1;

            int totalCoalCount = 0;

            for (int row = 0; row < n; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = currentRow[col];

                    if (field[row, col] == "s")
                    {
                        field[row, col] = "*";
                        minerRow = row;
                        minerCol = col;
                    }
                    else if (field[row, col] == "c")
                    {
                        totalCoalCount++;
                    }
                }
            }

            int coalColected = 0;

            bool isOver = false;
            bool isCollected = false;

            for (int i = 0; i < directions.Length; i++)
            {
                string direction = directions[i];

                int minerNewRow = minerRow;
                int minerNewCol = minerCol;

                switch (direction)
                {
                    case "up":
                        minerNewRow--;
                        break;
                    case "down":
                        minerNewRow++;
                        break;
                    case "left":
                        minerNewCol--;
                        break;
                    case "right":
                        minerNewCol++;
                        break;
                }

                if (!IsValidIndex(field, minerNewRow, minerNewCol))
                {
                    continue;
                }

                if (field[minerNewRow, minerNewCol] == "e")
                {
                    isOver = true;
                    minerRow = minerNewRow;
                    minerCol = minerNewCol;
                    break;
                }
                else if (field[minerNewRow,minerNewCol] == "c")
                {
                    coalColected++;
                    field[minerNewRow, minerNewCol] = "*";
                }

                minerRow = minerNewRow;
                minerCol = minerNewCol;

                if (coalColected == totalCoalCount)
                {
                    isCollected = true;
                    break;
                }

            }

            if (isCollected)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else if (isOver)
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{totalCoalCount - coalColected} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static bool IsValidIndex(string[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1));
        }
    }
}
