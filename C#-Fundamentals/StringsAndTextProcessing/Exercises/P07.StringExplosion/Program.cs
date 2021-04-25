using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialText = Console.ReadLine();

            string[] splitedText = initialText.Split('>');

            string resultText = splitedText[0];

            splitedText = splitedText.Skip(1).ToArray();
            int remainingPower = 0;

            for (int i = 0; i < splitedText.Length; i++)
            {
                resultText += ">";

                string currentPart = splitedText[i];
                int power = int.Parse(currentPart[0].ToString());
                power += remainingPower;

                if (power > currentPart.Length)
                {
                    remainingPower = power - currentPart.Length;
                }
                else
                {
                    resultText += currentPart.Remove(0, power);
                }

            }

            Console.WriteLine(resultText);
        }
    }
}
