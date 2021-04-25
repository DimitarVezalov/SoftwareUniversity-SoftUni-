using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private int initialSize = 3;

        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            
        }

        public override int Size => this.initialSize;

        public override void Eat()
        {
            this.initialSize += 3;
        }
    }
}
