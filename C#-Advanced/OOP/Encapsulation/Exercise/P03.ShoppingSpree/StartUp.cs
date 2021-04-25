using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleArgs = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<Person> people = new List<Person>();

            foreach (var personArgs in peopleArgs)
            {
                string[] currPersonArgs = personArgs
                    .Split('=',StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currPersonArgs[0];
                decimal money = decimal.Parse(currPersonArgs[1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    //return;
                }
            }

            string[] productsArgs = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<Product> products = new List<Product>();

            foreach (var productArgs in productsArgs)
            {
                string[] currProductArgs = productArgs
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currProductArgs[0];
                decimal money = decimal.Parse(currProductArgs[1]);

                try
                {
                    Product product = new Product(name, money);
                    products.Add(product);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string personName = cmdArgs[0];
                string productName = cmdArgs[1];

                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                if (person != null)
                {
                    if (product != null)
                    {
                        Console.WriteLine(person.BuyProduct(product));
                    }
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

        }
    }
}
