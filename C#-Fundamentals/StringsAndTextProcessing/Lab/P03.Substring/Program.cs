using System;
using System.Text;

namespace P03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstStr = Console.ReadLine().ToLower();
            string secondStr = Console.ReadLine();

            StringBuilder sb = new StringBuilder(secondStr);

            while (secondStr.Contains(firstStr))
            {
                sb = sb.Remove(secondStr.IndexOf(firstStr),firstStr.Length);
                secondStr = sb.ToString();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
