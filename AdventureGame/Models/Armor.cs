using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class Armor : Items
    {
        public Armor(string name, int str, int vit, int bPrice, int sPrice)
        {
            this.Name = name;
            this.Strenght = str;
            this.Vitality = vit;
            this.BuyPrice = bPrice;
            this.SellPrice = sPrice;

        }

    }
}
