using P04.PizzaCalories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Models.FlourTypes
{
    public class White : IFlourType
    {
        private const double DEFAULT_MODIFIER = 1.5;
        public double Modifier => DEFAULT_MODIFIER;
    }
}
