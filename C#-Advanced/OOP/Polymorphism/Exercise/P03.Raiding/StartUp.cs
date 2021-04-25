
using P03.Raiding.Factories;
using P03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                HeroFactory factory = null;

                switch (heroType)
                {
                    case "Druid":
                        factory = new DruidFactory(name);
                        break;
                    case "Paladin":
                        factory = new PaladinFactory(name);
                        break;
                    case "Rogue":
                        factory = new RogueFactory(name);
                        break;
                    case "Warrior":
                        factory = new WarriorFactory(name);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }

                if (factory != null)
                {
                    BaseHero hero = factory.CreateHero();
                    heroes.Add(hero);
                }
                else
                {
                    i --;
                }
               
            }

            int bossHealth = int.Parse(Console.ReadLine());

            foreach (BaseHero currentHero in heroes)
            {
                Console.WriteLine(currentHero.CastAbility());
            }

            int powerSum = heroes.Sum(h => h.Power);

            string output = powerSum >= bossHealth ? "Victory!" : "Defeat...";

            Console.WriteLine(output);
        }
    }
}
