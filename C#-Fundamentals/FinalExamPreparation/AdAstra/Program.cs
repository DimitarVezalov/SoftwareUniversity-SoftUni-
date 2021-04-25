using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"(#|\|)(?<itemName>[A-Za-z ]+)\1(?<itemDate>\d{2}/\d{2}/\d{2})\1(?<itemCalories>\d{1,4})\1");

            MatchCollection matches = regex.Matches(input);

            List<string> itemsInfo = new List<string>();

            int totalCalories = 0;

            foreach (Match match in matches)
            {
                string itemName = match.Groups["itemName"].Value;
                string itemDate = match.Groups["itemDate"].Value;
                int itemCalories = int.Parse(match.Groups["itemCalories"].Value);

                totalCalories += itemCalories;

                string itemInfo = $"Item: {itemName}, Best before: {itemDate}, Nutrition: {itemCalories}";

                itemsInfo.Add(itemInfo);
            }

            int days = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");
            Console.WriteLine(string.Join(Environment.NewLine, itemsInfo));
        }
    }
}
