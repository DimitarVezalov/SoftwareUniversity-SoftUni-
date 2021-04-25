using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Orders
{
    class Item
    {
        public Item(string name, double price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Item> orders = new List<Item>();

            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] itemArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = itemArgs[0];
                double price = double.Parse(itemArgs[1]);
                int quantity = int.Parse(itemArgs[2]);

                Item item = new Item(name , price, quantity);

                if (!orders.Any(i => i.Name == name))
                {
                    orders.Add(item);
                }
                else
                {
                    Item currentItem = orders.First(i => i.Name == name);
                    currentItem.Price = price;
                    currentItem.Quantity += quantity;
                }
                
            }

            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Name} -> {item.Price * item.Quantity:f2}");
            }
        }
    }
}
