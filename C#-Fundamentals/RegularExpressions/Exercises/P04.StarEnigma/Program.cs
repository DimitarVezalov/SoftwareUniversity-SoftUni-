using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Regex regex = new Regex(@"@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*:(?<population>\d+)[^\@\-\!\:\>]*!(?<attackType>[A|D])![^\@\-\!\:\>]*->(?<soldiers>\d+)");

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string message = Console.ReadLine();

                int key = GetCount(message);
                string decryptedMessage = "";
                
                for (int j = 0; j < message.Length; j++)
                {
                    int asciiCode = message[j] - key;

                    decryptedMessage += (char)asciiCode;
                }

                Match match = regex.Match(decryptedMessage);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;  
                    string attackType = match.Groups["attackType"].Value;

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(name);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(name);
                    }

                }

            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }

        }

        public static int GetCount(string message)
        {
            int key = 0;

            for (int i = 0; i < message.Length; i++)
            {
                char currChar = char.Parse(message[i].ToString().ToLower());

                if (currChar == 's' || currChar == 't' || currChar == 'a' || currChar == 'r')
                {
                    key++;
                }
            }

            return key;
        }
    }
}
