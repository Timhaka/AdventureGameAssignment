using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class StoreKeeper : NPC
    {
        public StoreKeeper(string Name)
        {
            this.Name = Name;
        }

        public override string SayHello(string name)
        {
            return base.SayHello(name) + $"I am {Name}. How may i help you?";
        }


    }
}
