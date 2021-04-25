using System;
using System.Transactions;

namespace CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());


            double apronsNeeded = Math.Ceiling(studentsCount * 1.2);
            double totalApronPrice = apronPrice * apronsNeeded;
            
            double flourNeeded = studentsCount - (studentsCount / 5);
            double totalFlourPrice = flourPrice * flourNeeded;

            double eggsNeeded = studentsCount * 10;
            double totalEggsPrice = eggsNeeded * eggPrice;

            double totalSumNeeded = totalApronPrice + totalEggsPrice + totalFlourPrice;

            if (budget >= totalSumNeeded)
            {
                Console.WriteLine($"Items purchased for {totalSumNeeded:f2}$.");
            }
            else
            {
                Console.WriteLine($"{totalSumNeeded - budget:f2}$ more needed.");
            }

        }
    }
}
