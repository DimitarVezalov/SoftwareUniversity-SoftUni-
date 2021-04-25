using System;
using System.Linq;

namespace P01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            int primarySum = 0;
            int secondarySum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];                  
                }

                primarySum += matrix[row, row];
                secondarySum += matrix[row, n - 1 - row];
            }    

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
           
        }
    }
}
