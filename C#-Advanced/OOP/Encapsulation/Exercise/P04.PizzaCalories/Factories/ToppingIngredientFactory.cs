using P04.PizzaCalories.Interfaces;
using P04.PizzaCalories.Models.ToppingIngredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Factories
{
    public static class ToppingIngredientFactory
    {
        public static IToppingIngredient CreateToppingIngredient(string type)
        {
            type = type.ToLower();
            IToppingIngredient topping = null;

            if (type == "meat")
            {
                topping = new Meat();
            }
            else if (type == "veggies")
            {
                topping = new Veggies();
            }
            else if (type == "sauce")
            {
                topping = new Sauce();
            }
            else if (type == "cheese")
            {
                topping = new Cheese();
            }

            return topping;
        }
    }
}
