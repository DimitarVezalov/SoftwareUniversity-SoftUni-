using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int DEFAULT_COMFORT = 5;
        private const int DEFAULT_PRICE = 10;

        public Plant()
            : base(DEFAULT_COMFORT, DEFAULT_PRICE)
        {
        }
    }
}
