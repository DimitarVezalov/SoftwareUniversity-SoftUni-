using P04.PizzaCalories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Models
{
    public class Topping
    {
        private const double DEFAULT_CALORIES_PER_GRAM = 2;
        private const double WEIGHT_MIN_VALUE = 1;
        private const double WEIGHT_MAX_VALUE = 50;


        private IToppingIngredient toppingIngredient;
        private double weight;

        public Topping(IToppingIngredient topping, double weight)
        {
            this.ToppingIngredient = topping;
            this.Weight = weight;
        }

        public IToppingIngredient ToppingIngredient
        {
            get
            {
                return this.toppingIngredient;
            }
            private set
            {
                if (value == null)
                {
                    throw new Exception("Cannot place {0} on top of your pizza.");
                }

                this.toppingIngredient = value;
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
                    string excMessage = $"{this.ToppingIngredient.GetType().Name}" +
                        $" weight should be in the range [{WEIGHT_MIN_VALUE}..{WEIGHT_MAX_VALUE}].";

                    throw new Exception(excMessage);
                       
                }

                this.weight = value;
            }
        }

        public double TotalCallories => (DEFAULT_CALORIES_PER_GRAM * this.Weight) 
                                                        * this.ToppingIngredient.Modifier; 
    }
}
