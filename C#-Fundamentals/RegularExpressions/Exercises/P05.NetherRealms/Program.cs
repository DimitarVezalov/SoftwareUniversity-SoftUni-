using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace P05.NetherRealms
{
    public class Demon
    {
        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"-?\d+\.?\d*";

            List<string> names = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<Demon> demons = new List<Demon>();

            char[] forbidenSymbols = { '+', '-', '/', '*', '.'};

            foreach (var name in names)
            {
                Demon demon = GetDemon(patern, forbidenSymbols, name);

                demons.Add(demon);

            }

            foreach (Demon currentDemon in demons.OrderBy(d => d.Name))
            {
                Console.WriteLine($"{currentDemon.Name} - {currentDemon.Health} health, {currentDemon.Damage:f2} damage");
            }
        }

        private static Demon GetDemon(string patern, char[] forbidenSymbols, string name)
        {
            int health = GetHealth(forbidenSymbols, name);

            MatchCollection matches = Regex.Matches(name, patern);
            double damage = GetDamage(name, matches);

            Demon demon = new Demon(name, health, damage);
            return demon;
        }

        private static double GetDamage(string name, MatchCollection matches)
        {
            double damage = matches.Select(m => m.Value).Select(double.Parse).ToArray().Sum();

            char[] operations = name.Where(x => x == '/' || x == '*').ToArray();

            if (operations.Any())
            {
                for (int i = 0; i < operations.Length; i++)
                {
                    if (operations[i] == '/')
                    {
                        damage /= 2;
                    }
                    else
                    {
                        damage *= 2;
                    }
                }
            }

            return damage;
        }

        private static int GetHealth(char[] forbidenSymbols, string name)
        {
            int health = 0;

            for (int i = 0; i < name.Length; i++)
            {
                char currentSymbol = name[i];
                if (!char.IsDigit(currentSymbol) && !forbidenSymbols.Contains(currentSymbol))
                {
                    health += currentSymbol;
                }
            }

            return health;
        }
    }
}
