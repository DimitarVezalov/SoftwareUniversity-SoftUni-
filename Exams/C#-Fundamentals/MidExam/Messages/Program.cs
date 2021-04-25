using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> logger = new List<string>();
               
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType != "Spam")
                {
                    string message = cmdArgs[1];

                    if (cmdType == "Chat")
                    {       
                        logger.Add(message);

                    }
                    else if (cmdType == "Delete")
                    {
                        if (logger.Contains(message))
                        {
                            logger.Remove(message);
                        }

                    }
                    else if (cmdType == "Edit")
                    {
                        string editedMessage = cmdArgs[2];
                        logger[logger.IndexOf(message)] = editedMessage;

                    }
                    else if (cmdType == "Pin")
                    {
                        logger.Remove(message);
                        logger.Add(message);

                    }

                }
                else
                {
                    string[] messages = cmdArgs.Skip(1).ToArray();
                    logger.AddRange(messages);

                }
           
            }

            Console.WriteLine(string.Join(Environment.NewLine, logger));
        }
    }
}
