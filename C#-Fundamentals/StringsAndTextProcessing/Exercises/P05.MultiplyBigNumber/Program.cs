using System;
using System.Text;
using System.Linq;

namespace P05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            if (number.All(x => x == '0') || multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder sb = new StringBuilder();

            int remainder = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(number[i].ToString());
                int result = currentDigit * multiplier + remainder;

                if (result > 9)
                {
                    remainder = result / 10;
                }
                else
                {
                    remainder = 0;
                }

                result = result % 10;
                sb.Append(result.ToString());

            }

            sb.Append(remainder.ToString());

            StringBuilder reversed = new StringBuilder();
            string resultText = sb.ToString();

            for (int i = resultText.Length - 1; i >= 0; i--)
            {
                reversed.Append(sb.ToString()[i]);
            }

            string reversedStr = reversed.ToString();

            while (reversedStr[0] == '0')
            {
                reversedStr = reversedStr.Substring(1);
            }

            Console.WriteLine(reversedStr);
        }
    }
}
