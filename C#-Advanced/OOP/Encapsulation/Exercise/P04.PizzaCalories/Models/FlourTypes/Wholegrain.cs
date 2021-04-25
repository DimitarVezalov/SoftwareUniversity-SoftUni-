using P04.PizzaCalories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Models.FlourTypes
{
    public class Wholegrain : IFlourType
    {
        private const double DEFAULT_MODIFIER = 1.0;
        public double Modifier => DEFAULT_MODIFIER;
    }
}
