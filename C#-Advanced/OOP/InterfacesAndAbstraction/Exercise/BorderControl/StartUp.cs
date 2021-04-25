using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> habitants = new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IIdentifiable habitant;

                if (inputArgs.Length == 3)
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];

                    habitant = new Citizen(name, age, id);
                }
                else
                {
                    string model = inputArgs[0];
                    string id = inputArgs[1];

                    habitant = new Robot(model, id);
                }

                habitants.Add(habitant);
            }

            string fakeId = Console.ReadLine();

            habitants = habitants
                .Where(h => h.Id.EndsWith(fakeId))
                .ToList();

            foreach (var habitant in habitants)
            {
                Console.WriteLine(habitant.Id);
            }
        }
    }
}
