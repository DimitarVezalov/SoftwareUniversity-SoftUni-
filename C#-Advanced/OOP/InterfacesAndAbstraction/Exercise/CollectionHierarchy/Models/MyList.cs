using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : IAddable, IRemoveable, IMyList
    {
        private IList<string> collection;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Count => this.collection.Count;

        public int Add(string item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            string item = this.collection[0];
            this.collection.RemoveAt(0);

            return item;
        }
    }
}
