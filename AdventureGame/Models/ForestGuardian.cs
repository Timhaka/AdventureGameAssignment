using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class ForestGuardian : NPC
    {
        public ForestGuardian()
        {
            this.Name = "Forest Guardian Kain";
        }

        public override string SayHello(string name)
        {
            return base.SayHello(name) + $"My name is {Name}.";
        }

    }
}
