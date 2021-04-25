using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SantaSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(?<name>\@[A-Za-z]+)[^\@\-\!\:\>]*\!(?<behavior>[GN])\!"); 

            int key = int.Parse(Console.ReadLine());

            List<string> goodKids = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string decryptedMessage = Decrypt(input , key);

                Match match = regex.Match(decryptedMessage);

                if (match.Success)
                {
                    string behavior = match.Groups["behavior"].Value;

                    if (behavior == "G")
                    {
                        string name = match.Groups["name"].Value;

                        goodKids.Add(name.Substring(1));
                    }
                }

            }

            Console.WriteLine(string.Join(Environment.NewLine, goodKids));
        }

        private static string Decrypt(string message, int key)
        {
            string decryptedMessage = "";

            for (int i = 0; i < message.Length; i++)
            {
                int currentCharCode = message[i] - key;
                decryptedMessage += (char)currentCharCode;
            }

            return decryptedMessage;
        }
    }
}
