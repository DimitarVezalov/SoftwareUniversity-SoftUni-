using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../text.txt";

            string patern = @"[\-,.!?]";

            Regex regex = new Regex(patern);

            using (StreamReader streamReader = new StreamReader(path))
            {
                string currentLine = streamReader.ReadLine();

                int count = 0;
                while (currentLine != null)
                {
                    if (count % 2 == 0)
                    {
                        currentLine = regex.Replace(currentLine, "@");
                        Console.WriteLine(string.Join(" ", currentLine.Split(" ").Reverse()));
                    }
                   
                    count++;
                    
                    currentLine = streamReader.ReadLine();
                }

            }
        }
    }
}
