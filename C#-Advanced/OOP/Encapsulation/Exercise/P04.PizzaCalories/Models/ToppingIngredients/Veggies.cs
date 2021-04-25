using P04.PizzaCalories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Models.ToppingIngredients
{
    public class Veggies : IToppingIngredient
    {
        private const double DEFAULT_MODIFIER = 0.8;
        public double Modifier => DEFAULT_MODIFIER;
    }
}
