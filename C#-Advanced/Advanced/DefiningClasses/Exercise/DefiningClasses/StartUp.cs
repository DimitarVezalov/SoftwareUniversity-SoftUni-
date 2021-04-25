using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateModifier dateModifier = new DateModifier();

            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            dateModifier.DayDifference(firstDate, secondDate);

        }
    }
}
