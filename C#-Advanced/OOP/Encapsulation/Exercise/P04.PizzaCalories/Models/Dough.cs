using P04.PizzaCalories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.PizzaCalories.Models
{
    public class Dough
    {
        private const double DEFAULT_CALORIES_PER_GRAM = 2;
        private const double WEIGHT_MIN_VALUE = 1;
        private const double WEIGHT_MAX_VALUE = 200;

        private IFlourType flourType;
        private IBakingTechnique bakingTechnique;
        private double weight;

        public Dough(IFlourType flourType, IBakingTechnique bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }


        public IFlourType FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (value == null)
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.flourType = value;
            }

        }

        public IBakingTechnique BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value == null)
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }


        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < WEIGHT_MIN_VALUE || value > WEIGHT_MAX_VALUE)
                {
                    string excMessage =
                            $"Dough weight should be in the range [{WEIGHT_MIN_VALUE}..{WEIGHT_MAX_VALUE}].";
                    throw new Exception(excMessage);
                }

                this.weight = value;
            }
        }

        public double TotalCalories => (DEFAULT_CALORIES_PER_GRAM * this.Weight) *
                                            this.FlourType.Modifier * this.BakingTechnique.Modifier;

    }
}
