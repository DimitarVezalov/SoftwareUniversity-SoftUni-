using P03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Raiding.Factories
{
    public abstract class HeroFactory
    {
        public HeroFactory(string name)
        {
            this.Name = name;
        }

        public string Name { get;}

        public abstract BaseHero CreateHero();       
    }
}
