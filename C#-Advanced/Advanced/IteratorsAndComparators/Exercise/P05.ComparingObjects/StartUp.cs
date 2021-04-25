using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] personArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                string town = personArgs[2];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[index];

            int matches = 0;

            foreach (var currPerson in people)
            {
                if (currPerson.CompareTo(personToCompare) == 0)
                {
                    matches++;
                }
            }

            int nonMatches = people.Count - matches;

            if (matches <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {nonMatches} {people.Count}");
            }
        }
    }
}
