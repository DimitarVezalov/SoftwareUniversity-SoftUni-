using System;

using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;


namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController _managerController;
        private IReader _reader;
        private IWriter _writer;

        public Engine(IManagerController managerController, IReader reader, IWriter writer)
        {
            this._managerController = managerController;
            this._reader = reader;
            this._writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string command = this._reader.ReadLine();

                if (command == "Exit")
                {
                    Environment.Exit(0);
                }

                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string output = "";

                try
                {
                    if (cmdType == "Report")
                    {
                        output = this._managerController.Report();

                    }
                    else
                    {
                        string firstToken = cmdArgs[1];
                        string secondToken = cmdArgs[2];

                        if (cmdType == "AddPlayer")
                        {
                            output = this._managerController.AddPlayer(firstToken, secondToken);
                        }
                        else if (cmdType == "AddCard")
                        {
                            output = this._managerController.AddCard(firstToken, secondToken);
                        }
                        else if (cmdType == "AddPlayerCard")
                        {
                            output = this._managerController.AddPlayerCard(firstToken, secondToken);
                        }
                        else if (cmdType == "Fight")
                        {
                            output = this._managerController.Fight(firstToken, secondToken);
                        }
                    }

                    this._writer.WriteLine(output);

                }
                catch (ArgumentException ae)
                {
                    this._writer.WriteLine(ae.Message);
                }

            }
        }
    }
}
