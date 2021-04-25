using P04.PizzaCalories.Interfaces;
using P04.PizzaCalories.Models.FlourTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Factories
{
    public static class FlourTypeFactory
    {
        public static IFlourType CreateFlourType(string type)
        {
            type = type.ToLower();
            IFlourType flourType = null;

            if (type == "white")
            {
                flourType = new White();
            }
            else if (type == "wholegrain")
            {
                flourType = new Wholegrain();
            }

            return flourType;
        }
    }
}
