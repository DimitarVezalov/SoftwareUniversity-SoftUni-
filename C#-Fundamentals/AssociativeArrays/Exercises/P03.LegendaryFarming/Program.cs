using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            string[] keyMaterialsArr = { "shards", "fragments", "motes" };

            foreach (var item in keyMaterialsArr)
            {
                keyMaterials[item] = 0;
            }

            bool isItemObtained = false;
            string keyMaterialStr = "";

            while (!isItemObtained)
            {
                string[] materials = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < materials.Length; i += 2)
                {

                    int quantity = int.Parse(materials[i]);
                    string material = materials[i + 1].ToLower();

                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials.Any(m => m.Value >= 250))
                        {
                            keyMaterialStr = keyMaterials.First(m => m.Value >= 250).Key;
                            keyMaterials[material] -= 250;
                            isItemObtained = true;
                            break;
                        }

                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] = 0;
                        }

                        junkMaterials[material] += quantity;
                    }

                }
            }

            string weaponType = GetWeaponType(keyMaterialStr);

            PrintOutput(keyMaterials, junkMaterials, weaponType);
        }

        private static void PrintOutput(Dictionary<string, int> keyMaterials, Dictionary<string, int> junkMaterials, string weaponType)
        {
            Console.WriteLine($"{weaponType} obtained!");

            foreach (var kvp in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static string GetWeaponType(string keyMaterialStr)
        {
            string obtainedWeapon = "";

            if (keyMaterialStr == "shards")
            {
                obtainedWeapon = "Shadowmourne";
            }
            else if (keyMaterialStr == "fragments")
            {
                obtainedWeapon = "Valanyr";
            }
            else if (keyMaterialStr == "motes")
            {
                obtainedWeapon = "Dragonwrath";
            }

            return obtainedWeapon;
        }
    }
}
