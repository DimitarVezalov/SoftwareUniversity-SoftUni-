using System;
using System.Collections.Generic;
using System.Text;

namespace P07.Tuple
{
    public class CustomTuple<T1, T2>
    {
        public CustomTuple(T1 first, T2 second)
        {
            this.FirstItem = first;
            this.SecondItem = second;
        }
        public T1 FirstItem { get; set; }

        public T2 SecondItem { get; set; }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem}";
        }
    }
}
