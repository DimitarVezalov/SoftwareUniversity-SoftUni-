using System;
using System.Collections.Generic;
using System.Text;

namespace P01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> collection;
        private int index = 0;

        public ListyIterator(params T[] elements)
        {
            this.collection = new List<T>(elements);
        }

        public bool Move()
        {
            if (this.index >= this.collection.Count - 1)
            {
                return false;
            }

            this.index++;

            return true;

        }

        public bool HasNext() => this.index + 1 <= this.collection.Count - 1;

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.collection[index]);
        }
    }
}
