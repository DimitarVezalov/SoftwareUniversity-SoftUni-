using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] effectsArr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] casingsArr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> bombEffects = new Queue<int>(effectsArr);
            Stack<int> bombCasings = new Stack<int>(casingsArr);

            int daturaBombsCount = 0;
            int cherryBombsCount = 0;
            int smokeDecoyBombsCounts = 0;

            bool isFull = false;


            while (bombCasings.Any() && bombEffects.Any())
            {
                isFull = daturaBombsCount >= 3 && cherryBombsCount >= 3 && smokeDecoyBombsCounts >= 3;

                if (isFull == true)
                {
                    break;
                }

                int sum = bombEffects.Peek() + bombCasings.Peek();

                if (CanCreateBomb(sum))
                {
                    if (sum == 40)
                    {
                        daturaBombsCount++;
                    }
                    else if (sum == 60)
                    {
                        cherryBombsCount++;
                    }
                    else if (sum == 120)
                    {
                        smokeDecoyBombsCounts++;
                    }

                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    bombCasings.Push(bombCasings.Pop() - 5);
                }  
            }

            if (isFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombsCount}\n" +
                                $"Datura Bombs: {daturaBombsCount}\n" +
                                $"Smoke Decoy Bombs: {smokeDecoyBombsCounts}");

            

        }

        private static bool CanCreateBomb(int sum)
        {
            return sum == 40 || sum == 60 || sum == 120;
        }
    }
}
