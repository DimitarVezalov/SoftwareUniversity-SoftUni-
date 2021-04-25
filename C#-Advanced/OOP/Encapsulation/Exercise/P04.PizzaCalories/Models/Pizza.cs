using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.PizzaCalories.Models
{
    public class Pizza
    {
        private const int NAME_MAX_LENGTH = 15;
        private const int TOPPINGS_MAX_COUNT = 10;
        private const int TOPPINGS_MIN_COUNT = 0;
        private string name;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public Dough Dough { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length > NAME_MAX_LENGTH)
                {
                    throw new Exception($"Pizza name should be between 1 and {NAME_MAX_LENGTH} symbols.");
                }

                this.name = value;
            }
        }

        public int ToppingsCount => this.toppings.Count;

        public IReadOnlyCollection<Topping> Toppings => this.toppings.AsReadOnly();

        public double TotalCalories => this.Dough.TotalCalories + this.toppings.Select(t => t.TotalCallories).Sum();

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= TOPPINGS_MAX_COUNT)
            {
                throw new Exception
                        ($"Number of toppings should be in range [{TOPPINGS_MIN_COUNT}..{TOPPINGS_MAX_COUNT}].");
            }

            this.toppings.Add(topping);
        }
    }
}
