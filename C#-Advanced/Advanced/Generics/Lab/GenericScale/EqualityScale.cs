using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
        where T: IComparable<T>
    {
        public EqualityScale(T first, T second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; }
        public T Second { get; }

        public bool AreEqual()
        {
            if (this.First.Equals(this.Second))
            {
                return true;
            }

            return false;           
        }
    }
}
