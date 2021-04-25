using System;
using System.Collections.Generic;
using System.IO;

namespace P02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputpPath = "../../../text.txt";
            string outputPath = "../../../output.txt";

            string[] lines = File.ReadAllLines(inputpPath);

            List<string> outputLines = new List<string>();

            int rowNumber = 1;
            foreach (var line in lines)
            {
                int lettersCount = 0;
                int marksCount = 0;

                foreach (var symbol in line)
                {
                    if (char.IsLetter(symbol))
                    {
                        lettersCount++;
                    }
                    else if (char.IsPunctuation(symbol))
                    {
                        marksCount++;
                    }
                    
                }

                string currentLine = $"Line{rowNumber}: {line} ({lettersCount})({marksCount})";
                outputLines.Add(currentLine);

                rowNumber++;
            }

            File.WriteAllLines(outputPath ,outputLines);
         }
    }
}
