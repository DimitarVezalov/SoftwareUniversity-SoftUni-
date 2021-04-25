using System;
using System.Text;

namespace P04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int asciiCode = text[i] + 3;
                
                sb.Append((char)asciiCode);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
