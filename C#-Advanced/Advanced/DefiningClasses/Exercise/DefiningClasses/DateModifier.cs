using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {

        public void DayDifference(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);   
            DateTime dateTwo = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

            TimeSpan timeSpan = dateOne - dateTwo;
            int daysDifference = timeSpan.Days;

            Console.WriteLine(Math.Abs(daysDifference));
        }
    }
}
