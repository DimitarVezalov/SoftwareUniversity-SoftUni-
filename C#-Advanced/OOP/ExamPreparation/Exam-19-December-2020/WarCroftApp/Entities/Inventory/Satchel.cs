using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int DEFAULT_CAPACITY = 20;

        public Satchel() 
            : base(DEFAULT_CAPACITY)
        {
        }
    }
}
