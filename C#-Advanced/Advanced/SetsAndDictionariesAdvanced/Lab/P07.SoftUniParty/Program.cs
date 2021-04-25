using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> ordinaryGuests = new HashSet<string>();

            string input;

            while ((input = Console.ReadLine()) !="PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    ordinaryGuests.Add(input);
                }  
            }

            string reservationNumbers;
            while ((reservationNumbers = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(reservationNumbers[0]))
                {
                    vipGuests.Remove(reservationNumbers);
                }
                else
                {
                    ordinaryGuests.Remove(reservationNumbers);
                }
            }

            Console.WriteLine(vipGuests.Count + ordinaryGuests.Count);

            if (vipGuests.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipGuests));
            }
            if (ordinaryGuests.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, ordinaryGuests));
            }
        }
    }
}
