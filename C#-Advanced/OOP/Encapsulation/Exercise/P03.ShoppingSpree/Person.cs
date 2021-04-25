using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();

        public string BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.bag.Add(product);
                this.Money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string productsString = this.Bag.Any() ? $"{string.Join(", ", this.Bag.Select(x => x.Name))}" : "Nothing bought";

            sb.AppendLine($"{this.Name} - {productsString}");

            return sb.ToString().TrimEnd();
        }
    }
}
