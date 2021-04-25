using System;
using System.Linq;

namespace P03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePath = Console.ReadLine()
                .Split('\\', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string fileFullName = filePath[filePath.Length - 1];

            string[] fileArgs = fileFullName.Split('.', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string fileName = fileArgs[0];
            string fileExtension = fileArgs[1];

            Console.WriteLine($"File name: {fileName}\nFile extension: {fileExtension}");
        }
    }
}
