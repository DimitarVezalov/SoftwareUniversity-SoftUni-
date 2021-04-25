using System;
using System.Collections.Generic;
using System.Text;

namespace P08.Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        public Threeuple(T1 first, T2 second, T3 third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }

        public T1 First { get; set; }
        public T2 Second { get; set; }
        public T3 Third { get; set; }

        public override string ToString()
        {
            return $"{this.First} -> {this.Second} -> {this.Third}";
        }
    }
}
