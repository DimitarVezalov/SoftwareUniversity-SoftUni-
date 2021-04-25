using EasterRaces.Core.Contracts;
using System;
using EasterRaces.IO.Contracts;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class Engine
    {
        private readonly IChampionshipController controller;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IChampionshipController championshipController, IReader reader, IWriter writer)
        {
            this.controller = championshipController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            StringBuilder sb = new StringBuilder();

            string command = this.reader.ReadLine();

            while (command != "End")
            {
                try
                {
                    var args = command.Split();
                    var cmdType = args[0];
                    string resultMessage = string.Empty;

                    if (cmdType == "CreateDriver")
                    {
                        resultMessage = this.controller.CreateDriver(args[1]);
                    }
                    else if (cmdType == "StartRace")
                    {
                        resultMessage = this.controller.StartRace(args[1]);
                    }
                    else if (cmdType == "CreateRace")
                    {
                        resultMessage = this.controller.CreateRace(args[1], int.Parse(args[2]));
                    }
                    else if (cmdType == "CreateCar")
                    {
                        resultMessage = this.controller.CreateCar(args[1], args[2], int.Parse(args[3]));
                    }
                    else if (cmdType == "AddCarToDriver")
                    {
                        resultMessage = this.controller.AddCarToDriver(args[1], args[2]);
                    }
                    else if (cmdType == "AddDriverToRace")
                    {
                        resultMessage = this.controller.AddDriverToRace(args[1], args[2]);
                    }

                    sb.AppendLine(resultMessage);
                }
                catch (Exception e)
                {
                    sb.AppendLine(e.Message);
                }

                command = this.reader.ReadLine();
            }

            this.writer.WriteLine(sb.ToString());
        }

    }
}
