using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddable, IRemoveable
    {
        private IList<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            string item = this.collection.Last();

            this.collection.Remove(this.collection.Last());

            return item;
        }
    }
}
