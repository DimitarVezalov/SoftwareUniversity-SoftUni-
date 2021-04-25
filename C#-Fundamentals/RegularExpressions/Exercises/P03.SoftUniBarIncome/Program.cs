using System;
using System.Text.RegularExpressions;

namespace P03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^%(?<name>[A-Z]{1}[a-z]+)%[^\$\|%\.]*<(?<product>\w+)>[^\$\|%\.]*\|(?<quantity>\d+)\|[^\$\|%\.]*?(?<price>\d+\.?\d*)\$$");

            double totalIncome = 0;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    totalIncome += quantity * price;

                    Console.WriteLine($"{name}: {product} - {quantity*price:f2}");
                }
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
