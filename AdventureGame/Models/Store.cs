using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class Store : Areas
    {
       //enum NameWeapons {ShortSword=1,FlameSword, }
        public List<Items> ItemList { get; set; }
        StoreKeeper cid { get; set; }
       
        public Store()
        {
            this.AreaName = "General Store";
            cid = new StoreKeeper("StoreKeeper Cid");
            ItemList = new List<Items>();
            //name str vit bprice sprice dmg
            ItemList.Add(new Weapons("Short Sword", 5, 5, 10, 2, "3-12"));
            ItemList.Add(new Weapons("Long Sword", 10, 5, 30, 10, "7-18"));
            ItemList.Add(new Weapons("Masamune", 15, 10, 60, 10, "12-24"));
            ItemList.Add(new Weapons("Soul Edge", 25, 15, 100, 10, "18-28"));
            ItemList.Add(new Weapons("Blade of Chaos", 50, 30, 150, 10, "28-42"));
            // name  str vit bprice sprice
            ItemList.Add(new Armor("Chain Mail", 5, 10, 10, 5));
            ItemList.Add(new Armor("Plate Mail", 10, 15, 25, 2));
            ItemList.Add(new Armor("Gold Armor", 15, 25, 50, 2));
            ItemList.Add(new Armor("Mythril Armor", 25, 40, 100, 2));

            ItemList.Add(new Shields("Wooden Shield", 2, 5, 10, 3));
            ItemList.Add(new Shields("Plate Shield", 9, 13, 25, 5));
            ItemList.Add(new Shields("Gold Shield", 13, 30, 50, 5));
            ItemList.Add(new Shields("Magic Shield", 25, 40, 100, 5));




        }
        
        public void EnterStore(string name, Player user)
        {

            Console.WriteLine(cid.SayHello(name));
            Console.WriteLine("");
            
            //Console.WriteLine("If you defeat all monsters in the forest i will be able to sell you better weapons");
            this.p1 = user;
        }

        public string GeneralStoreInventory()
        {
            string information = "";
            int count = 1;
            Graphics graphic = new Graphics();
            graphic.WritePlayerBox();
            graphic.PlayerInfo(p1);
            foreach (Items inv in ItemList)
            {
                information += "--------------------\n";
                information += $"{count}. Name: {inv.Name}\n   Strenght: {inv.Strenght}\n   Vitality: {inv.Vitality}\n   Price: {inv.BuyPrice}\n";
                count++;
            }
            
            return information;
        }

        public void BuyFromStore()
        {
            int answer = 0;
            do
            {
                Console.Clear();
                Graphics graphic = new Graphics();
                graphic.WritePlayerBox();
                graphic.PlayerInfo(p1);
                graphic.SpeakBox();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("what would you like to buy?");
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("1. Weapons");
                Console.SetCursorPosition(2, 3);
                Console.WriteLine("2. Armor");
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("3. Shields");
                Console.SetCursorPosition(2, 5);
                Console.WriteLine("4. Potions");
                Console.SetCursorPosition(2, 6);
                Console.WriteLine("5. Exit Store");
                Console.SetCursorPosition(2, 7);

                string shopAnswer = Console.ReadLine();
                bool result = Int32.TryParse(shopAnswer, out answer);

                if (result && answer <= 5)
                {

                    switch (answer)
                    {
               
                        case 1:
                            Console.Clear();
                            graphic.WritePlayerBox();
                            graphic.PlayerInfo(p1);
                            var obj = ItemList.Where(x => x.GetType().Name == "Weapons").ToList();
                            int count = 1;

                            foreach (Weapons item in obj)
                            {
                                Console.WriteLine($"{count}. {item.Name}\nDamage: {item.Damage}\nPrice: {item.BuyPrice}\n");
                                count++;
                            }
                           
                            int choice;
                            Console.WriteLine("Which item would you like to Buy?");
                            string answerShop = Console.ReadLine();
                            bool storeChoice = Int32.TryParse(answerShop, out choice);
                            if (storeChoice && choice <= obj.Count())
                            {
                                if (p1.Gil < obj[choice - 1].BuyPrice)
                                {
                                    Console.WriteLine("Sorry you do not have enough gil to buy that.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    p1.SpendMoney(obj[choice - 1].BuyPrice);
                                    p1.AddInventory(obj[choice - 1]);
                                    p1.SetEquipment(obj[choice - 1]);

                                }

                            }


                            break;
                        case 2:
                            Console.Clear();
                            graphic.WritePlayerBox();
                            graphic.PlayerInfo(p1);
                            var armo = ItemList.Where(x => x.GetType().Name == "Armor").ToList();
                            int count2 = 1;

                            foreach (var item in armo)
                            {
                                Console.WriteLine($"{count2}. {item.Name} \nVitality: {item.Vitality} \nPrice: {item.BuyPrice}\n");
                                count2++;
                            }
                            
                            int choiceA;
                            Console.WriteLine("Which item would you like to Buy?");
                            string choiceArmo = Console.ReadLine();
                            bool storeChoiceArmo = Int32.TryParse(choiceArmo, out choiceA);
                            if (storeChoiceArmo && choiceA <= armo.Count())
                            {

                                if (p1.Gil < armo[choiceA - 1].BuyPrice)
                                {
                                    Console.WriteLine("Sorry you do not have enough gil to buy that.");
                                    Console.ReadKey();
                                }
                                else
                                {

                                    p1.SpendMoney(armo[choiceA - 1].BuyPrice);
                                    p1.AddInventory(armo[choiceA - 1]);
                                    p1.SetEquipment(armo[choiceA - 1]);

                                }
                            }
                            break;
                        case 3:
                            Console.Clear();
                            graphic.WritePlayerBox();
                            graphic.PlayerInfo(p1);


                            var shi = ItemList.Where(x => x.GetType().Name == "Shields").ToList();
                            int count1 = 1;

                            foreach (var item in shi)
                            {
                                Console.WriteLine($"{count1}. {item.Name} \nVitality: {item.Vitality} \nPrice: {item.BuyPrice}\n");
                                count1++;
                            }
                            
                            int choiceS;
                            Console.WriteLine("Which item would you like to Buy?");
                            string answerShops = Console.ReadLine();
                            bool storeChoiceS = Int32.TryParse(answerShops, out choiceS);
                            if (storeChoiceS && choiceS <= shi.Count())
                            {

                                if (p1.Gil < shi[choiceS - 1].BuyPrice)
                                {
                                    Console.WriteLine("Sorry you do not have enough gil to buy that.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    p1.SpendMoney(shi[choiceS - 1].BuyPrice);
                                    p1.AddInventory(shi[choiceS - 1]);
                                    p1.SetEquipment(shi[choiceS - 1]);

                                }
                            }
                            break;
                            
                        case 4:

                            int amount;

                            do
                            {
                                //Hard to get this to work properly,
                                Console.Clear();
                                graphic.SpeakBox();
                                Console.WriteLine("Potions in inventory " + p1.PotionsInInventory());
                                Console.SetCursorPosition(2, 2);
                                Console.WriteLine("Potion cost 50 each and will heal you to full HP");
                                Console.SetCursorPosition(2, 3);
                                Console.WriteLine("can only carry 4 potions at the time.");
                                Console.SetCursorPosition(2, 4);
                                Console.WriteLine("How many would you like to buy?");
                                Console.SetCursorPosition(2, 5);
                                string amountP = Console.ReadLine();
                                bool amountBool = Int32.TryParse(amountP, out amount);
                                int i;

                                if (amountBool && p1.PotionsInInventory() < 4)
                                {

                                    if (p1.PotionsInInventory() == 4)
                                    {
                                        Console.SetCursorPosition(2, 6);
                                        Console.WriteLine("You cant have any more potions");
                                        Console.ReadKey();
                                        break;
                                    }
                                    else
                                    {
                                        if (p1.Gil < (amount * 50))
                                        {
                                            Console.SetCursorPosition(2, 6);
                                            Console.WriteLine("Sorry you do not have enough gil to buy that.");

                                            Console.ReadKey();
                                        }
                                        else if (p1.Gil > (amount * 50) && amount <=4)
                                        {
                                            if (amount == 1)
                                            {
                                                p1.SpendMoney(50 * amount);
                                                p1.AddInventory(new Potions());
                                                Console.SetCursorPosition(2, 6);
                                                Console.WriteLine($"Buying {amount} potion");
                                                Console.ReadKey();
                                                break;
                                            }

                                            for (i = 0; i < amount; i++)
                                            {

                                              
                                                if (p1.PotionsInInventory() == 4)
                                                {
                                                    Console.SetCursorPosition(2, 6);
                                                    Console.WriteLine($"you have {p1.PotionsInInventory() - i} potions.");
                                                    Console.SetCursorPosition(2, 7);
                                                    Console.WriteLine("You can only carry 4 potions at the same time.");
                                                    Console.SetCursorPosition(2, 8);
                                                    Console.WriteLine($"Buying {i} amount of potions");
                                                    Console.ReadKey();

                                                    break;
                                                }
                                                p1.SpendMoney(50);
                                                p1.AddInventory(new Potions());
                                                Console.SetCursorPosition(2, 6);
                                                Console.WriteLine($"Buying {amount} potion");
                                                

                                            }
                                            Console.ReadKey();
                                            break;

                                        }
                                        else if (amount > 4) 
                                        {
                                            Console.SetCursorPosition(2, 8);
                                            Console.WriteLine("Can only have a max amount of 4");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                                else
                                {
                                    Console.SetCursorPosition(2, 6);
                                    Console.WriteLine("Cant buy more potions");
                                    Console.ReadKey();
                                    break;

                                }
                                

                            } while (amount > 0);
                        
                            break;
                        case 5:
                            Console.SetCursorPosition(2, 8);
                            Console.WriteLine("Bye Bye!");
                            break;
                        
                    }
                }
                else
                {
                    Console.SetCursorPosition(2, 8);
                    Console.WriteLine("Invalid input, please enter in between 1 - 5");
                    Console.ReadKey();
                }
            } while (answer != 5);


        }

        public void ForestCleared(bool statement)
        {
            
            if (statement == true)
            {
                ItemList.Add(new Weapons("Excalibur", 100, 80, 250, 0, "50-100"));
                ItemList.Add(new Armor("Genji Armor", 50, 100, 150, 0));
                ItemList.Add(new Shields("Genji Shield", 50, 100, 150, 0));
            }
        }



    }
}
