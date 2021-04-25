using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> morseAlphabet = GetMorseAlphabet();

            string[] code = Console.ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < code.Length; i++)
            {
                string codeWord = code[i];

                string[] codeWordChars = codeWord.Split().Where(w => w != "" && w != " ").ToArray();

                foreach (var item in codeWordChars)
                {
                    sb.Append(morseAlphabet[item]);
                }

                sb.Append(" ");
            }

            Console.WriteLine(sb.ToString());
        }

        private static Dictionary<string, string> GetMorseAlphabet()
        {
            Dictionary<string, string> morseAlphabet = new Dictionary<string, string>();
            morseAlphabet[".-"] = "A";
            morseAlphabet["-..."] = "B";
            morseAlphabet["-.-."] = "C";
            morseAlphabet["-.."] = "D";
            morseAlphabet["."] = "E";
            morseAlphabet["..-."] = "F";
            morseAlphabet["--."] = "G";
            morseAlphabet["...."] = "H";
            morseAlphabet[".."] = "I";
            morseAlphabet[".---"] = "J";
            morseAlphabet["-.-"] = "K";
            morseAlphabet[".-.."] = "L";
            morseAlphabet["--"] = "M";
            morseAlphabet["-."] = "N";
            morseAlphabet["---"] = "O";
            morseAlphabet[".--."] = "P";
            morseAlphabet["--.-"] = "Q";
            morseAlphabet[".-."] = "R";
            morseAlphabet["..."] = "S";
            morseAlphabet["-"] = "T";
            morseAlphabet["..-"] = "U";
            morseAlphabet["...-"] = "V";
            morseAlphabet[".--"] = "W";
            morseAlphabet["-..-"] = "X";
            morseAlphabet["-.--"] = "Y";
            morseAlphabet["--.."] = "Z";
            return morseAlphabet;
        }
    }
}
