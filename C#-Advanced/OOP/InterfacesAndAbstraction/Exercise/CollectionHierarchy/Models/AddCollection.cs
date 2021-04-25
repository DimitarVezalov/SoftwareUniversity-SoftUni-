using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        private ICollection<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Add(item);

            return this.collection.Count - 1;
        }
    }
}
