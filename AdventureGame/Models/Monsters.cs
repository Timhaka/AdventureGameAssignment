using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class Monsters
    {
        public string Name { get; set; }
        public string AttackName { get; set; }
        public int HP { get; set; }
        public int GilDrop { get; set; }
        public Random Amount { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int MaxHP { get; set; }

        public virtual int Attack()
        {
            Amount = new Random();
            int attack = Amount.Next(1, 2);
            return attack;

        }

        public virtual int SpecialAttack()
        {
            Amount = new Random();
            int attack = Amount.Next(1, 2);
            return attack;
        }
        public virtual void LoseHp(int dmg)
        {
            this.HP -= dmg;
        }
        public virtual int GiveExp()
        {
            return 10;
        }

    }

}
