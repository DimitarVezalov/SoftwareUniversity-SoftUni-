using System;
using System.Text;

namespace P01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int nameStartIndex = text.IndexOf('@') + 1;
                int nameEndIndex = text.IndexOf('|');

                int ageStartIndex = text.IndexOf('#') + 1;
                int ageEndIndex = text.IndexOf('*');

                string name = text.Substring(nameStartIndex, nameEndIndex - nameStartIndex);
                string ageStr = text.Substring(ageStartIndex, ageEndIndex - ageStartIndex);

                Console.WriteLine($"{name} is {int.Parse(ageStr)} years old.");

            }
        }
    }
}
