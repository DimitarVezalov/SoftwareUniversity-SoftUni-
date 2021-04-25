using P04.PizzaCalories.Factories;
using P04.PizzaCalories.Interfaces;
using P04.PizzaCalories.Models;
using System;
using System.Linq;

namespace P04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaArgs = Console.ReadLine()
                .Split(" ")
                .ToArray();

            Pizza pizza = null;

            try
            {
                pizza = new Pizza(pizzaArgs[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string[] doughArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            IFlourType flour = FlourTypeFactory.CreateFlourType(doughArgs[1]);
            IBakingTechnique bakingTechnique = BakingTechniqueFactory.CreateBakingTechnique(doughArgs[2]);
            double doughWeight = double.Parse(doughArgs[3]);

            try
            {
                Dough dough = new Dough(flour, bakingTechnique, doughWeight);
                pizza.Dough = dough;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] toppingArgs = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                IToppingIngredient toppingIngredient = ToppingIngredientFactory.CreateToppingIngredient(toppingArgs[1]);
                double toppingWeight = double.Parse(toppingArgs[2]);

                try
                {
                    Topping topping = new Topping(toppingIngredient, toppingWeight);
                    pizza.AddTopping(topping);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message, toppingArgs[1]);
                    return;
                }
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            
        }
    }
}
