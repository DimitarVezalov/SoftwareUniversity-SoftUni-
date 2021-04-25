using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int DEFAULT_COMFORT = 1;
        private const int DEFAULT_PRICE = 5;

        public Ornament() 
            : base(DEFAULT_COMFORT, DEFAULT_PRICE)
        {
        }
    }
}
