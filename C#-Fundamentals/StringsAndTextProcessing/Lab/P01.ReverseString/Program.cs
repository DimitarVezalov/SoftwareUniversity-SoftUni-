using System;
using System.Linq;

namespace P01.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            while ((text = Console.ReadLine()) != "end")
            {
                char[] reversed = text.Reverse().ToArray();

                Console.WriteLine($"{text} = {string.Join("", reversed)}");
                               
            }
        }
    }
}
