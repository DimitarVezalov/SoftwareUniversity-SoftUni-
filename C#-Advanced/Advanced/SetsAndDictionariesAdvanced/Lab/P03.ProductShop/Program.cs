using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopsInfo = new Dictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] shopArgs = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string shopName = shopArgs[0];
                string productName = shopArgs[1];
                double price = double.Parse(shopArgs[2]);

                if (!shopsInfo.ContainsKey(shopName))
                {
                    shopsInfo[shopName] = new Dictionary<string, double>();
                }

                shopsInfo[shopName].Add(productName, price);
            }

            shopsInfo = shopsInfo.OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in shopsInfo)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var product in kvp.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
