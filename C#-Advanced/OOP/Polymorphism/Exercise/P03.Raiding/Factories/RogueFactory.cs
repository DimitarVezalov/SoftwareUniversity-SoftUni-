using P03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Raiding.Factories
{
    public class RogueFactory : HeroFactory
    {
        public RogueFactory(string name) 
            : base(name)
        {
        }

        public override BaseHero CreateHero()
        {
            return new Rogue(this.Name);
        }
    }
}
