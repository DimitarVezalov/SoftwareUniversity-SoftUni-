using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] ingredientsArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidsArr);
            Stack<int> ingredients = new Stack<int>(ingredientsArr);

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;

            bool canBeCoocked = false;
            bool isAllCoocked = false;

            while (liquids.Any() && ingredients.Any())
            {
                int sum = liquids.Peek() + ingredients.Peek();

                canBeCoocked = sum == 25 || sum == 50 || sum == 75 || sum == 100;

                if (canBeCoocked)
                {
                    if (sum == 25)
                    {
                        breadCount++;
                    }
                    else if (sum == 50)
                    {
                        cakeCount++;
                    }
                    else if (sum == 75)
                    {
                        pastryCount++;
                    }
                    else
                    {
                        fruitPieCount++;
                    }

                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }

                if (breadCount >= 1 && cakeCount >= 1 && pastryCount >= 1 && fruitPieCount >= 1)
                {
                    isAllCoocked = true;  
                }

            }

            if (isAllCoocked)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            string liquidsLeft = liquids.Any() ? string.Join(", ", liquids) : "none";

            Console.WriteLine($"Liquids left: {liquidsLeft}");

            string ingredientsLeft = ingredients.Any() ? string.Join(", ", ingredients) : "none";

            Console.WriteLine($"Ingredients left: {ingredientsLeft}");

            Console.WriteLine($"Bread: {breadCount}\n" +
                                $"Cake: {cakeCount}\n" +
                                $"Fruit Pie: {fruitPieCount}\n" +
                                $"Pastry: {pastryCount}");
        }
    }
}
