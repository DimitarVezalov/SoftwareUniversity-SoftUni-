using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroesOfCodeAndLogicVII
{
    class Hero
    {
        public Hero(string name, int hP, int mP)
        {
            this.Name = name;
            this.HP = hP;
            this.MP = mP;
        }

        public string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(this.Name)
                .AppendLine($"  HP: {this.HP}")
                .AppendLine($"  MP: {this.MP}");

            return sb.ToString().TrimEnd();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Hero> heroes = new List<Hero>();

            for (int i = 0; i < count; i++)
            {
                AddHeroes(heroes);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(" - ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = cmdArgs[0];
                string name = cmdArgs[1];

                Hero hero = heroes
                    .FirstOrDefault(h => h.Name == name);

                if (type == "CastSpell")
                {
                    CastSpell(cmdArgs, name, hero);
                }
                else if (type == "TakeDamage")
                {
                    TakeDamage(heroes, cmdArgs, name, hero);
                }
                else if (type == "Recharge")
                {
                    RechargeMp(cmdArgs, name, hero);

                }
                else if (type == "Heal")
                {
                    HealHp(cmdArgs, name, hero);
                }

            }

            heroes = heroes
                .OrderByDescending(h => h.HP)
                .ThenBy(h => h.Name)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, heroes));
        }

        private static void HealHp(string[] cmdArgs, string name, Hero hero)
        {
            int amount = int.Parse(cmdArgs[2]);

            int currentHp = hero.HP;

            int rechargedHp = (currentHp + amount) > 100 ? (100 - currentHp) : amount;

            hero.HP += rechargedHp;
            Console.WriteLine($"{name} healed for {rechargedHp} HP!");
        }

        private static void RechargeMp(string[] cmdArgs, string name, Hero hero)
        {
            int amount = int.Parse(cmdArgs[2]);

            int currentMp = hero.MP;

            int rechargedAmount = (currentMp + amount) > 200 ? (200 - currentMp) : amount;

            hero.MP += rechargedAmount;
            Console.WriteLine($"{name} recharged for {rechargedAmount} MP!");
        }

        private static void TakeDamage(List<Hero> heroes, string[] cmdArgs, string name, Hero hero)
        {
            int damage = int.Parse(cmdArgs[2]);
            string attacker = cmdArgs[3];

            if (hero.HP > damage)
            {
                hero.HP -= damage;
                Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {hero.HP} HP left!");
            }
            else
            {
                heroes.Remove(hero);
                Console.WriteLine($"{name} has been killed by {attacker}!");
            }
        }

        private static void CastSpell(string[] cmdArgs, string name, Hero hero)
        {
            int mPNeeded = int.Parse(cmdArgs[2]);
            string spellName = cmdArgs[3];

            if (hero.MP >= mPNeeded)
            {
                hero.MP -= mPNeeded;
                Console.WriteLine($"{name} has successfully cast {spellName} and now has {hero.MP} MP!");
            }
            else
            {
                Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
            }
        }

        private static void AddHeroes(List<Hero> heroes)
        {
            string[] heroArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string name = heroArgs[0];
            int hP = int.Parse(heroArgs[1]);
            int mP = int.Parse(heroArgs[2]);

            Hero hero = new Hero(name, hP, mP);
            heroes.Add(hero);
        }
    }
}
