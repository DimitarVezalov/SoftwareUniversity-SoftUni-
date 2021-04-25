using P04.PizzaCalories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Models.ToppingIngredients
{
    public class Cheese : IToppingIngredient
    {
        private const double DEFAULT_MODIFIER = 1.1;
        public double Modifier => DEFAULT_MODIFIER;
    }
}
