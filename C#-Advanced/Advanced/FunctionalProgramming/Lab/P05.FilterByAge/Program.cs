using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FilterByAge
{
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = personArgs[0];
                int personAge = int.Parse(personArgs[1]);

                Person person = new Person(personName, personAge);

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();


            Func<Person, bool> filterFunc = condition switch
            {
                "younger" => p => p.Age < age,
                "older" => p => p.Age >= age,
                _ => c => true
            };

            Func<Person, string> result = format switch
            {
                "name" => p => $"{p.Name}",
                "age" => p => $"{p.Age}",
                "name age" => p => $"{p.Name} - {p.Age}",
                _ => c => null
            };

            List<string> output = people
                .Where(filterFunc)
                .Select(result)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, output));
        }
    }
}
