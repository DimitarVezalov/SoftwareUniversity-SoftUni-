using System;

namespace P08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personArgs = Console.ReadLine().Split();
            string fullName = $"{personArgs[0]} {personArgs[1]}";
            string adress = personArgs[2];
            string town = personArgs[3];

            string[] personAndBeer = Console.ReadLine().Split();
            string name = personAndBeer[0];
            int litersAmount = int.Parse(personAndBeer[1]);
            bool isDrunk = personAndBeer[2] == "drunk";

            string[] accountArgs = Console.ReadLine().Split();
            string accountName = accountArgs[0];
            double balance = double.Parse(accountArgs[1]);
            string bankName = accountArgs[2];

            Threeuple<string, string, string> firstTuple =
                        new Threeuple<string, string, string>(fullName, adress, town);

            Threeuple<string, int, bool> secondTuple =
                        new Threeuple<string, int, bool>(name, litersAmount, isDrunk);

            Threeuple<string, double, string> thirdTuple =
                        new Threeuple<string, double, string>(accountName, balance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
