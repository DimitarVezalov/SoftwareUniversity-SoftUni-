using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int numberOfPeople;
        private int capacity;
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson; 
        }

        public int TableNumber { get; private set; } 

        public int Capacity
        {
            get => this.capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;



        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        public decimal GetBill()
        {
            decimal bill = 0;

            foreach (var food in this.foodOrders)
            {
                bill += food.Price;
            }

            foreach (var drink in drinkOrders)
            {
                bill += drink.Price;
            }

            return bill; 
        }

        public void OrderDrink(IDrink drink)
        {
            if (drink != null)
            {
                this.drinkOrders.Add(drink);
            }
        }

        public void OrderFood(IBakedFood food)
        {
            if (food != null)
            {
                this.foodOrders.Add(food);
            }
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();

            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Table: {this.TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
    }
}
