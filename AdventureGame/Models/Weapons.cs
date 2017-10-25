using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class Weapons : Items
    {

        public string Damage { get; set; }
        public Weapons(string name, int str, int vit, int bPrice, int sPrice, string dmg)
        {
            this.Name = name;
            this.Strenght = str;
            this.Vitality = vit;
           // this.Effect = effect;
            this.BuyPrice = bPrice;
            this.SellPrice = sPrice;
            this.Damage = dmg;
        }

       

    }
}
