using P03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Raiding.Factories
{
    public class PaladinFactory : HeroFactory
    {
        public PaladinFactory(string name)
            : base(name)
        {
        }

        public override BaseHero CreateHero()
        {
            return new Paladin(this.Name);
        }
    }
}
