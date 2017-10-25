﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class ForestReapers : Monsters
    {

        public ForestReapers(string name, int minDamage, int maxDamage, int hp, int gilmin, int gilmax)
        {
            Amount = new Random();
            this.Name = name;
            this.HP = hp;
            this.GilDrop = Amount.Next(gilmin, gilmax);
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.MaxHP = hp;
            this.AttackName = "Wind Cutter";
        }

        public override int Attack()
        {
            Amount = new Random();
            int attack = Amount.Next(MinDamage, MaxDamage);
            return attack;
        }
        public override int SpecialAttack()
        {
            Amount = new Random();
            int attack = Amount.Next(MinDamage + 20 , MaxDamage + 20);
            return attack;
        }
        public override void LoseHp(int dmg)
        {
            this.HP -= dmg;
        }
        public override int GiveExp()
        {
            return base.GiveExp() + GilDrop;
        }
    }
}