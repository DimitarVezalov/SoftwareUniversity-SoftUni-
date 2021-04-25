using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpinionPoll
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            foreach (var person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine(person.Name + " - " + person.Age);
            }

        }
    }
}
