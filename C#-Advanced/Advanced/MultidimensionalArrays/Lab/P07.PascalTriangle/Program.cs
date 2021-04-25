using System;

namespace P07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[n][];
            pascalTriangle[0] = new long[1];
            pascalTriangle[0][0] = 1;

            for (int row = 1; row < n; row++)
            {
                pascalTriangle[row] = new long[row + 1];

                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    long first = (row - 1 >= 0 && row - 1 < n) && 
                                (col >= 0 && col < pascalTriangle[row].Length - 1)
                                    ? pascalTriangle[row - 1][col] : 0;

                    long second = (row - 1 >= 0 && row - 1 < n) && 
                                (col - 1 >= 0 && col - 1 < pascalTriangle[row].Length)
                                     ? pascalTriangle[row - 1][col - 1] : 0;

                    long value = first + second;

                    pascalTriangle[row][col] = value;
                }
            }

            PrintTriangle(n, pascalTriangle);
        }

        private static void PrintTriangle(int n, long[][] pascal)
        {
            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ", pascal[row]));
            }
        }
    }
}
