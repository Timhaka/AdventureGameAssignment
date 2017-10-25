using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int Gil { get; set; }
        public int EXP { get; set; }
        public int Strenght { get; set; }
        public int Vitality { get; set; }
        public int AmountUntilNextLvl { get; set; }
        public int MaxHP { get; set; }
        public Items Weapon { get; set; }
        public Items Armor { get; set; }
        public Items Shield { get; set; }
        public int Age { get; set; }
        public List<Items> Pinventory { get; set; }

        public Random Damage { get; set; }
        public Player(string name, int age)
        {
            this.Weapon = new Weapons("Club", 0, 0, 0, 1, "2-9");
            this.Armor = new Armor("Cloth", 0, 0, 0, 1);
            this.Shield = new Shields("Glove", 0, 0, 0, 0);
            Pinventory = new List<Items>();
           
            Pinventory.Add(this.Weapon);
            Pinventory.Add(this.Armor);
            Pinventory.Add(this.Shield);

            //sets default name
            if (name == "" || name.Length > 6)
            {
                Name = "Duke";
            }
            else
            {
                Name = name;
            }
            Age = age;
            Gil = 5;
            EXP = 0;
            Vitality = 0;
            Level = 1;
           
            HP = 100;
            MaxHP = 100;
            AmountUntilNextLvl = 100;


        }
        // equip items and set the right vitality values.
        public void SetEquipment(Items item)
        {
            if (item is Weapons)
            {
                Vitality -= Weapon.Vitality;
                Strenght -= Weapon.Strenght;
                MaxHP -= Weapon.Vitality;
                this.Weapon = item;

                this.Strenght = this.Weapon.Strenght + this.Armor.Strenght + this.Shield.Strenght;
                this.Vitality = this.Weapon.Vitality + this.Armor.Vitality + this.Shield.Vitality;
                this.MaxHP += Vitality;
                this.HP = MaxHP;
            }
            else if (item is Armor)
            {
                Vitality -= Armor.Vitality;
                Strenght -= Armor.Strenght;
                MaxHP -= Armor.Vitality;
                this.Armor = item;
                this.Strenght = this.Weapon.Strenght + this.Armor.Strenght + this.Shield.Strenght;
                this.Vitality = this.Weapon.Vitality + this.Armor.Vitality + this.Shield.Vitality;
                this.MaxHP += Vitality;
                this.HP = MaxHP;

            }
            else if (item is Shields)
            {
                Vitality -= Shield.Vitality;
                Strenght -= Shield.Strenght;
                MaxHP -= Shield.Vitality;

                this.Shield = item;
                this.Strenght = this.Weapon.Strenght + this.Armor.Strenght + this.Shield.Strenght;
                this.Vitality = this.Weapon.Vitality + this.Armor.Vitality + this.Shield.Vitality;
                this.MaxHP += Vitality;
                this.HP = MaxHP;
            }
        }

        public string Inventory()
        {
            int count = 1;
            string information = "";
            foreach (Items inv in Pinventory)
            {
                information += "--------------------\n";
                information += $"{count}. Name: {inv.Name}\n   Strenght: {inv.Strenght}\n   Vitality: {inv.Vitality}\n   Type: {inv.GetType().Name}\n";
                count++;
            }

            return information;
        }
        public int PotionsInInventory()
        {
            var obj = Pinventory.Where(p => p.Name == "Potion");
            return obj.Count();
        }
        public void AddInventory(Items item)
        {
            Pinventory.Add(item);
        }
        public void RemoveInventory(Items item)
        {
            Pinventory.Remove(item);
        }

        public int SpendMoney(int money)
        {
            Gil -= money;
            return Gil;
        }
        public void GainMoney(int money)
        {
            Gil += money;
        }
        public int Attack()
        {
            int attack = 0;
            if (this.Weapon.Name == "Club")
            {
                Damage = new Random();
                attack = Damage.Next(2, 9) + this.Strenght;
            }
            else if (this.Weapon.Name == "Short Sword")
            {
                Damage = new Random();
                attack = Damage.Next(3, 12) + this.Strenght;
            }
            else if (this.Weapon.Name == "Long Sword")
            {
                Damage = new Random();
                attack = Damage.Next(7, 18) + this.Strenght;
            }
            else if (this.Weapon.Name == "Masamune")
            {
                Damage = new Random();
                attack = Damage.Next(12, 24) + this.Strenght;
            }
            else if (this.Weapon.Name == "Soul Edge")
            {
                Damage = new Random();
                attack = Damage.Next(18, 28) + this.Strenght;
            }
            else if (this.Weapon.Name == "Blade of Chaos")
            {
                Damage = new Random();
                attack = Damage.Next(28, 42) + this.Strenght;
            }
            else if (this.Weapon.Name == "Excalibur")
            {
                Damage = new Random();
                attack = Damage.Next(50, 100) + this.Strenght;
            }
            
            return attack;
        }
       
        public void UsePotion()
        {
            var obj = Pinventory.Where(p => p.Name == "Potion");
           
            foreach (Potions item in obj)
            {
                if (item.Name == "Potion")
                {
                    Pinventory.Remove(item);
                    Console.WriteLine($"Using a Potion");
                    Console.SetCursorPosition(2,13);
                    Console.WriteLine($"You have { obj.Count()} Potions left");

                        this.HP = this.MaxHP;
                   
                    break;
                }
                else
                {
                    Console.WriteLine("No Potions in your inventory!");
                    
                }
            }

        }

        public void LoseHp(int dmg)
        {
            this.HP -= dmg;
        }

        public void GainXP(int XP)
        {
            this.EXP += XP;
        }
        public void GainLvl(Player p1)
        {
            

            if (p1.EXP > AmountUntilNextLvl)
            {
                int tempExp = 0;
                if (p1.EXP > AmountUntilNextLvl)
                {
                    tempExp = p1.EXP - AmountUntilNextLvl;
                }
                Level++;
                this.Level = Level;
                this.EXP = tempExp;
                tempExp = 0;
                AmountUntilNextLvl += 30*Level;
                int strlvl = 5;
                int vitlvl = 10;

                this.Strenght += strlvl;
                this.Vitality += vitlvl;
                this.MaxHP += Vitality;
                Graphics graphic = new Graphics();
                graphic.LevelInformation();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You gained a Level!");
                Console.SetCursorPosition(43, 3);
                Console.WriteLine($"strenght increased with {strlvl}");
                Console.SetCursorPosition(43, 4);
                Console.WriteLine($"Vitality Incresead with {vitlvl}");
                Console.SetCursorPosition(43, 5);
                Console.WriteLine($"Xp until next lvl is {AmountUntilNextLvl}");
                Console.ResetColor();
                //Console.WriteLine("str is now"+ this.Strenght);

            }
            
        }

    }
}
