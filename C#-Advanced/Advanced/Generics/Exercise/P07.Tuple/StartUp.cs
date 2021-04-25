using System;
using System.Linq;

namespace P07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] personArgs = Console.ReadLine().Split();
            string fullName = $"{personArgs[0]} {personArgs[1]}";
            string adress = personArgs[2];

            string[] personAndBeer = Console.ReadLine().Split();
            string name = personAndBeer[0];
            int litersAmount = int.Parse(personAndBeer[1]);

            string[] numbers = Console.ReadLine().Split();
            int integer = int.Parse(numbers[0]);
            double realNumber = double.Parse(numbers[1]);

            CustomTuple<string, string> firstTuple = new CustomTuple<string, string>(fullName, adress);
            CustomTuple<string, int> secondTuple = new CustomTuple<string, int>(name, litersAmount);
            CustomTuple<int, double> thirdTuple = new CustomTuple<int, double>(integer, realNumber);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
