using DefiningClasses;
using System;
using System.Linq;

namespace OldestFamilyMember
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < count; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            Person oldest = family.GetOldestMember();

            Console.WriteLine(oldest.Name + " " + oldest.Age);
        }
    }
}
