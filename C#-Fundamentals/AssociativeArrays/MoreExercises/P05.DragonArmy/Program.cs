using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.DragonArmy
{
    class Dragon
    {
        //{type} {name} {damage} {health} {armor}
        private const int DEFAULT_DAMAGE = 45;
        private const int DEFAULT_HEALTH = 250;
        private const int DEFAULT_ARMOR = 10;

        public Dragon(string type, string name)
        {
            this.Type = type;
            this.Name = name;
            this.Damage = DEFAULT_DAMAGE;
            this.Health = DEFAULT_HEALTH;
            this.Armor = DEFAULT_ARMOR;
            
        }

        public string Type { get; set; }

        public string Name { get; set; }

        public int Damage { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Dragon> dragons = new List<Dragon>();

            int countOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfDragons; i++)
            {
                string[] dragonArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = dragonArgs[0];
                string name = dragonArgs[1];
                string damage = dragonArgs[2];
                string health = dragonArgs[3];
                string armor = dragonArgs[4];

                Dragon dragon = new Dragon(type, name);

                if (damage != "null")
                {
                    int damageStat = int.Parse(damage);

                    dragon.Damage = damageStat;
                }

                if (health != "null")
                {
                    int healthStat = int.Parse(health);

                    dragon.Health = healthStat;
                }

                if (armor != "null")
                {
                    int armorStat = int.Parse(armor);

                    dragon.Armor = armorStat;
                }

                if (dragons.Any(d => d.Type == type && d.Name == name))
                {
                    Dragon currentDragon = dragons.First(d => d.Type == type && d.Name == name);

                    currentDragon.Damage = dragon.Damage;
                    currentDragon.Health = dragon.Health;
                    currentDragon.Armor = dragon.Armor;
                }
                else
                {
                    dragons.Add(dragon);
                }

            }

            List<string> types = new List<string>();

            foreach (var dragon in dragons)
            {
                if (!types.Contains(dragon.Type))
                {
                    types.Add(dragon.Type);
                }

                
            }

            foreach (var type in types)
            {
                double avgDamage = 0;
                double avgHealth = 0;
                double avgArmor = 0;
                foreach (var dragon in dragons)
                {
                    if (dragon.Type == type)
                    {
                        avgDamage += dragon.Damage;
                        avgHealth += dragon.Health;
                        avgArmor += dragon.Armor;

                    }
                }

                int count = dragons.Where(d => d.Type == type).Count();
                avgDamage /= count;
                avgHealth /= count;
                avgArmor /= count;

                Console.WriteLine($"{type}::({avgDamage:f2}/{avgHealth:f2}/{avgArmor:f2})");

                foreach (var dragon in dragons.Where(d => d.Type == type).OrderBy(d => d.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}," +
                        $" health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
            
        }
    }
}
