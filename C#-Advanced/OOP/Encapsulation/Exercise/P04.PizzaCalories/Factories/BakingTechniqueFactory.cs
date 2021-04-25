using P04.PizzaCalories.Interfaces;
using P04.PizzaCalories.Models.BakingTechniques;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Factories
{
    public static class BakingTechniqueFactory
    {
        public static IBakingTechnique CreateBakingTechnique(string type)
        {
            type = type.ToLower();
            IBakingTechnique bakingTechnique = null;

            if (type == "crispy")
            {
                bakingTechnique = new Crispy();
            }
            else if (type == "chewy")
            {
                bakingTechnique = new Chewy();
            }
            else if (type == "homemade")
            {
                bakingTechnique = new Homemade();
            }

            return bakingTechnique;
        }
    }
}
