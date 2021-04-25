using System;
using System.Linq;

namespace P06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if ((row >= 0 && row < rows) &&(col >= 0 && col <matrix[row].Length))
                {
                    if (cmdType == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else if (cmdType == "Subtract")
                    {
                        matrix[row][col] -= value;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
