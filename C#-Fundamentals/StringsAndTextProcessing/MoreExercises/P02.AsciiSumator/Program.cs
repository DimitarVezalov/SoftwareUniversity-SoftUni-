using System;

namespace P02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char startChar = char.Parse(Console.ReadLine());
            char endChar = char.Parse(Console.ReadLine());

            string text = Console.ReadLine();

            int sum = 0;

            foreach (var symbol in text)
            {
                if (symbol > startChar && symbol < endChar)
                {
                    sum += symbol;
                }

            }

            Console.WriteLine(sum);
        }
    }
}
