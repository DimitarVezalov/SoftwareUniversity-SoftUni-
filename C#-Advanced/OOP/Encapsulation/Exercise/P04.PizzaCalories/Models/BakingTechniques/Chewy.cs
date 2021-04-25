using P04.PizzaCalories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Models.BakingTechniques
{
    public class Chewy : IBakingTechnique
    {
        private const double DEFAULT_MODIFIER = 1.1;
        public double Modifier => DEFAULT_MODIFIER;
    }
}
