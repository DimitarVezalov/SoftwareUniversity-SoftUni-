using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rng = new Random();

            int index = rng.Next(0, this.Count);

            string randomString = this[index];

            this.RemoveAt(index);

            return randomString;
        }
    }
}
