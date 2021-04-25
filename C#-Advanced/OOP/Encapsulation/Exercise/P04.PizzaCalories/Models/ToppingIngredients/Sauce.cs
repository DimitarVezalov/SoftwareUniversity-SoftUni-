using P04.PizzaCalories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Models.ToppingIngredients
{
    public class Sauce : IToppingIngredient
    {
        private const double DEFAULT_MODIFIER = 0.9;
        public double Modifier => DEFAULT_MODIFIER;
    }
}
