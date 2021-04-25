using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Raiding.Models
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public virtual int Power { get;}

        public abstract string CastAbility();
    }
}
