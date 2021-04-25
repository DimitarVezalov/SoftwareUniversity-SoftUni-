using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> citizensAndPets = new List<IBirthable>(); 

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IBirthable birthable = null;

                if (inputArgs[0] == "Citizen")
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    DateTime birthDate = DateTime.ParseExact(inputArgs[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    birthable = new Citizen(name, age, id, birthDate);

                }
                else if (inputArgs[0] == "Pet")
                {
                    string name = inputArgs[1];
                    DateTime birthDate = DateTime.ParseExact(inputArgs[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    birthable = new Pet(name, birthDate);
                }

                if (birthable != null)
                {
                    citizensAndPets.Add(birthable);
                }
                

            }

            int year = int.Parse(Console.ReadLine());

            foreach (var birthable in citizensAndPets.Where(b => b.Birthdate.Year == year))
            {
                Console.WriteLine(birthable.Birthdate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            }
        }
    }
}
