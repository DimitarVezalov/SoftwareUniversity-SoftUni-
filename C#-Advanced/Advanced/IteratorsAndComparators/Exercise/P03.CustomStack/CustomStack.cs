using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private readonly List<T> _elements;

        public CustomStack()
        {
            this._elements = new List<T>();
        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                this._elements.Add(element);
            }
        }

        public T Pop()
        {

            if (!this._elements.Any())
            {
                throw new InvalidOperationException("No elements");
            }

            T element = this._elements[this._elements.Count - 1];
            this._elements.RemoveAt(this._elements.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this._elements.Count - 1; i >= 0; i--)
            {
                yield return this._elements[i];
            }

            for (int i = this._elements.Count - 1; i >= 0; i--)
            {
                yield return this._elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
