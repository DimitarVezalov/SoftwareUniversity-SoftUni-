using FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Citizen : IBuyer, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; }

        public int Age { get; }

        public int FoodAmount { get; private set; }

        public string Id { get; }

        public DateTime Birthdate { get; }


        public void BuyFood()
        {
            this.FoodAmount += 10;
        }
    }
}
