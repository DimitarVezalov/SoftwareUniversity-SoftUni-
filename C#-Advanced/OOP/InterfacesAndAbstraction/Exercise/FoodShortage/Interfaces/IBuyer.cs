using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Interfaces
{
    public interface IBuyer : IPerson
    {
        public int FoodAmount { get;}

        void BuyFood();
    }
}
