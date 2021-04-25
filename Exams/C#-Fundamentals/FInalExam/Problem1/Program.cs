using System;
using System.Linq;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialText = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "Translate")
                {
                    string old = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    initialText = initialText.Replace(old, replacement);

                    Console.WriteLine(initialText);
                }
                else if (cmdType == "Includes")
                {
                    string text = cmdArgs[1];

                    Console.WriteLine(initialText.Contains(text));
                }
                else if (cmdType == "Start")
                {
                    string text = cmdArgs[1];

                    Console.WriteLine(initialText.StartsWith(text));
                }
                else if (cmdType == "Lowercase")
                {
                    initialText = initialText.ToLower();
                    Console.WriteLine(initialText);
                }
                else if (cmdType == "FindIndex")
                {
                    char currChar = char.Parse(cmdArgs[1]);

                    for (int i = initialText.Length - 1; i >= 0; i--)
                    {
                        if (initialText[i] == currChar)
                        {
                            Console.WriteLine(i);
                            break;
                        }
                    }
                }
                else if (cmdType == "Remove")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int count = int.Parse(cmdArgs[2]);

                    if (startIndex > -1 && startIndex < initialText.Length)
                    {
                        initialText = initialText.Remove(startIndex, count);
                        Console.WriteLine(initialText);
                    }
                    
                }
            }

        }
    }
}
