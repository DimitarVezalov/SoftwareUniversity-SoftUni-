using ExplicitInterfaces.Interfaces;
using System;
using System.Linq;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = citizenArgs[0];
                string country = citizenArgs[1];
                int age = int.Parse(citizenArgs[2]);

                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen as IPerson;
                IResident resident = citizen as IResident;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
