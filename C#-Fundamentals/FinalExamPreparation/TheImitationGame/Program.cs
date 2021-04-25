using System;
using System.Linq;

namespace TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = command
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = cmdArgs[0];

                if (type == "Move")
                {
                    int count = int.Parse(cmdArgs[1]);

                    string substring = encryptedMessage.Substring(0,count);
                    encryptedMessage = encryptedMessage.Remove(0,count);
                    encryptedMessage += substring;

                }
                else if (type == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];

                    encryptedMessage = encryptedMessage.Insert(index,value);
                }
                else if (type == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    encryptedMessage = encryptedMessage.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
