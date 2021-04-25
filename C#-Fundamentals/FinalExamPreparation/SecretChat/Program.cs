using System;
using System.Linq;


namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] cmdArgs = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];

                if (cmdType == "InsertSpace")
                {
                    int index = int.Parse(cmdArgs[1]);

                    concealedMessage = concealedMessage.Insert(index, " ");

                    Console.WriteLine(concealedMessage);

                }
                else if (cmdType == "Reverse")
                {
                    string substring = cmdArgs[1];

                    if (!concealedMessage.Contains(substring))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    int index = concealedMessage.IndexOf(substring);
                    concealedMessage = concealedMessage.Remove(index, substring.Length);

                    string reversed = ReverseSubstring(substring);

                    concealedMessage = concealedMessage += reversed;

                    Console.WriteLine(concealedMessage);
                }
                else if (cmdType == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    concealedMessage = concealedMessage.Replace(substring, replacement);

                    Console.WriteLine(concealedMessage);

                }
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }

        public static string ReverseSubstring(string substring)
        {
            string reversed = "";

            for (int i = substring.Length - 1; i >= 0; i--)
            {
                reversed += substring[i];
            }

            return reversed;
        }
    }
}
