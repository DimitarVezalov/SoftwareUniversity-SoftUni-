using System;
using System.Linq;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] cmdArgs = command
                    .Split(">>>",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "Contains")
                {
                    string substring = cmdArgs[1];

                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }

                }
                else if (cmdType == "Flip")
                {
                    string upperOrLower = cmdArgs[1];
                    int startIndex = int.Parse(cmdArgs[2]);
                    int endIndex = int.Parse(cmdArgs[3]);

                    string substring = activationKey.Substring(startIndex,endIndex - startIndex);
                    string substitute = "";

                    if (upperOrLower == "Upper")
                    {
                        substitute = substring.ToUpper();
                    }
                    else
                    {
                        substitute = substring.ToLower();
                    }

                    activationKey = activationKey.Replace(substring, substitute);
                    Console.WriteLine(activationKey);

                }
                else if (cmdType == "Slice")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    activationKey = activationKey.Remove(startIndex, endIndex- startIndex);

                    Console.WriteLine(activationKey);
                }

            }

            Console.WriteLine($"Your activation key is: {activationKey}");

        }
    }
}
