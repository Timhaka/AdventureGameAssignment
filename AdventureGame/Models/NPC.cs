using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class NPC
    {
        public string Name { get; set; }

        public virtual string SayHello(string name)
        {
            return $"Hello {name}! ";
        }
    }
}
