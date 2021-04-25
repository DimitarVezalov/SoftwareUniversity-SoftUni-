using FoodShortage.Interfaces;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IBuyer buyer = CreateBuyer(inputArgs);

                if (buyer != null)
                {
                    buyers.Add(buyer);
                }
            }

            while (true)
            {
                string inputName = Console.ReadLine();

                if (inputName == "End")
                {
                    break;
                }

                foreach (var buyer in buyers)
                {
                    if (buyer.Name == inputName)
                    {
                        buyer.BuyFood();
                    }
                }

            }

            int totalFood = buyers.Select(b => b.FoodAmount).Sum();

            Console.WriteLine(totalFood);
        }

        private static IBuyer CreateBuyer(string[] inputArgs)
        {
            IBuyer buyer = null;

            string name = inputArgs[0];
            int age = int.Parse(inputArgs[1]);

            if (inputArgs.Length == 4)
            {
                string id = inputArgs[2];
                DateTime birthdate = DateTime.ParseExact(inputArgs[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                buyer = new Citizen(name, age, id, birthdate);
            }
            else
            {
                string group = inputArgs[2];

                buyer = new Rebel(name, age, group);
            }

            return buyer;
        }
    }
}
