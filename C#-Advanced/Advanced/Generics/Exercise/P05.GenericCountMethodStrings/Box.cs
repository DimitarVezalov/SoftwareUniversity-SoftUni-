using System;
using System.Collections.Generic;
using System.Text;

namespace P05.GenericCountMethodStrings
{
    class Box<T>
        where T: IComparable<T>
    {
        private List<T> elements;

        public Box()
        {
            this.elements = new List<T>();
        }

        public Box(List<T> elements)
        {
            this.Elements = elements;

        }
        public List<T> Elements
        {
            get
            {
                return this.elements;
            }
            private set
            {
                this.elements = value;
            }
        }

        public int CountBiggerElements(T compareValue)
        {
            int count = 0;

            foreach (var element in this.elements)
            {
                if (element.CompareTo(compareValue) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in this.elements)
            {
                sb.AppendLine($"{element.GetType().FullName}: {element}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
