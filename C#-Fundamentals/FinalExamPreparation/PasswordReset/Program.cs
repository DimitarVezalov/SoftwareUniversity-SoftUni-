using System;
using System.Linq;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialText = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (cmdArgs[0] == "TakeOdd")
                {
                    initialText = TakeOdd(initialText);
                }
                else if (cmdArgs[0] == "Cut")
                {
                    initialText = Cut(initialText, cmdArgs);
                }
                else if (cmdArgs[0] == "Substitute")
                {
                    initialText = Substitute(initialText, cmdArgs);

                }

            }

            Console.WriteLine($"Your password is: {initialText}");
        }

        private static string Substitute(string initialText, string[] cmdArgs)
        {
            string substring = cmdArgs[1];

            if (initialText.Contains(substring))
            {
                string substitute = cmdArgs[2];

                initialText = initialText.Replace(substring, substitute);

                Console.WriteLine(initialText);
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }

            return initialText;
        }

        private static string Cut(string initialText, string[] cmdArgs)
        {
            int index = int.Parse(cmdArgs[1]);
            int count = int.Parse(cmdArgs[2]);

            initialText = initialText.Remove(index, count);

            Console.WriteLine(initialText);
            return initialText;
        }

        private static string TakeOdd(string initialText)
        {
            string newText = "";

            for (int i = 0; i < initialText.Length; i++)
            {
                if (i % 2 != 0)
                {
                    newText += initialText[i];
                }
            }

            initialText = newText;

            Console.WriteLine(initialText);
            return initialText;
        }
    }
}
