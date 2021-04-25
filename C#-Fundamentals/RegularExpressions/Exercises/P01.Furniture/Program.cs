using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"[>]{2}(?<type>[A-Z]+[a-z]*)[<]{2}(?<price>\d+\.?\d*)!(?<quantity>\d+)");

            double totalMoneySpend = 0;
            List<string> furnituresBought = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string type = match.Groups["type"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    furnituresBought.Add(type);
                    totalMoneySpend += price * quantity;

                }
            }

            Console.WriteLine($"Bought furniture:");
            foreach (var item in furnituresBought)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalMoneySpend:f2}");
        }
    }
}
