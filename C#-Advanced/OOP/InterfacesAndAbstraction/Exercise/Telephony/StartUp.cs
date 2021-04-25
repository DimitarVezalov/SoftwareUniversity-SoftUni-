using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] sites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartPhone = new Smartphone();

            foreach (string number in phoneNumbers)
            {
                if (number.Length == 7)
                {
                    try
                    {
                        Console.WriteLine(stationaryPhone.Call(number)); 
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                else
                {
                    try
                    {
                        Console.WriteLine(smartPhone.Call(number));
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }

            foreach (string site in sites)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(site));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                
                }
            }
        }
    }
}
