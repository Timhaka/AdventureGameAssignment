using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace AdventureGame.Models
{
    class Menys
    {
        
        public static void startMeny()
        {     
            Store shop = new Store();
            Forest evilForest = new Forest();
            Tavern tev = new Tavern();
            DarkCaves caves = new DarkCaves();
            Graphics graphic = new Graphics();
            
            
            bool res = false;
            int pAge = 0;
            string player = "";
            while (res == false || player.Contains("\t")) {
                Console.Clear();
                graphic.SpeakBox();
                
                Console.WriteLine($"Hey Adventurer! Welcome to our town, i am Cid and i own");
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("the General Store in this town.");
                Console.SetCursorPosition(2, 3);
                Console.WriteLine();
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("What is your name adventurer? ( Max 6 characters)");


                Console.SetCursorPosition(2, 5);
                Console.Write("Enter Name: ");
                Console.SetCursorPosition(14, 5);
                player = Console.ReadLine();
                
                Console.SetCursorPosition(2, 6);
                Console.WriteLine("Enter Age: ");
              
                Console.SetCursorPosition(13, 6);
                string age = Console.ReadLine();
                
                res = Int32.TryParse(age, out pAge);
                if (player.Contains("\t") || res == false)
                {
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("Please enter correct name and age");
                    Console.ReadKey();
                }

            }

            Player p1 = new Player(player, pAge);
            Console.Clear();
            Console.CursorVisible = false;
            //WriteMenuBoxSetPos(p1);
            //Console.WriteLine("");
            graphic.SpeakBox();
            // Console.CursorLeft
            //Console.SetCursorPosition(1, 1);
            Console.WriteLine($"Cid:");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine($"Okey {p1.Name}, if you need any equipment or potions come visit");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine($"me at the store. If you need information or want to");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine($"rest you could always go to the {tev.AreaName}.");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine($"Please be careful if you are considering going to the");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine($"{evilForest.AreaName}. There are many dangerous monsters");
            Console.SetCursorPosition(2, 7);
            Console.WriteLine($"lurking in the forest. I'll see you around {p1.Name},");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine($"Bye Bye!");
            Console.SetCursorPosition(0, 0);
            
            Console.CursorVisible = true;

            
            int userInput = 0;
           // Console.WriteLine($"The adventeruer {p1.Name} come to a hunted town which was located in \nbetween a Dark cave and a forest");
            Console.ReadKey();
            SoundPlayer townMusic = new SoundPlayer();
            townMusic.SoundLocation = Environment.CurrentDirectory + @"\TownTheme.wav";
            townMusic.PlayLooping();

            do
            {
                Console.Clear();
              //  System.Media.SoundPlayer townMusic = new System.Media.SoundPlayer(@"C:\Users\timha\source\repos\AdventureGame\AdventureGame\TownTheme.wav");
                
                
                //WriteMenuBoxSetPos();
                //PlayerInfo(p1);
                graphic.WritePlayerBox();
                graphic.PlayerInfo(p1);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                graphic.SpeakBox();
                Console.WriteLine("Where do I want to go");
                Console.SetCursorPosition(2, 2);
                Console.WriteLine($"1. {tev.AreaName}");
                Console.SetCursorPosition(2, 3);
                Console.WriteLine($"2. The {shop.AreaName}");
                Console.SetCursorPosition(2, 4);
                Console.WriteLine($"3. Show {p1.Name}'s Inventory/stats");
                Console.SetCursorPosition(2, 5);
                Console.WriteLine($"4. {evilForest.AreaName}");
                Console.SetCursorPosition(2, 6);
                Console.WriteLine($"5. {caves.AreaName}");
                Console.SetCursorPosition(2, 7);
                Console.WriteLine($"6. Quit Game");
                Console.SetCursorPosition(2, 8);



                string answer = Console.ReadLine();
                userInput = 0;
                bool result = Int32.TryParse(answer, out userInput);

                if (result && userInput <= 6)
                {

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                          
                        tev.EnterTavern(p1);
                        Console.ReadKey();

                        break;
                    case 2:
                        Console.Clear();
                       
                            
                            graphic.WritePlayerBox();
                            graphic.PlayerInfo(p1);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            graphic.SpeakBox();
                            shop.EnterStore(p1.Name, p1);
                            Console.WriteLine("");
                            Console.SetCursorPosition(2, 2);
                            Console.WriteLine("1. show inventory");
                            Console.SetCursorPosition(2, 3);
                            Console.WriteLine("2. Buy Items");
                            Console.SetCursorPosition(2, 4);
                            Console.WriteLine("3. Exit");
                            Console.SetCursorPosition(2, 5);





                            string answerShop = Console.ReadLine();
                            int choice = 0;
                            bool shopResult = Int32.TryParse(answerShop, out choice);
                            
                            if (shopResult && choice <= 3)
                                {
                                switch (choice)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine(shop.GeneralStoreInventory());
                                        Console.ReadKey();
                                        goto case 2;
                                        
                                    case 2:
                                        shop.BuyFromStore();
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        Console.SetCursorPosition(2, 7);
                                        Console.WriteLine("Bye Bye!");
                                        Console.ReadKey();
                                        break;
                                        
                                }
                                
                                
                                }
                                else if (result)
                                {
                                    Console.SetCursorPosition(2, 7);
                                    Console.WriteLine("Invalid input, please enter in between 1 - 3");
                                    Console.ReadKey();
                                    goto case 2;
                                }
                                break;
                    case 3:
                        Console.Clear();
                        graphic.WritePlayerBox();
                        graphic.PlayerStats(p1);
                        Console.WriteLine(p1.Inventory());
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                      
                        evilForest.EnterForest(p1.Name, p1, shop);
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                            townMusic.Stop();
                            if (p1.Inventory().Contains("Holy Torch") == true)
                            {
                                caves.EnterDarkCaves(p1, shop);
                            }
                            else if (p1.Inventory().Contains("Holy Torch") != true) // need to look at this! sound does not work
                            {
                                SoundPlayer dragon = new SoundPlayer();
                                dragon.SoundLocation = Environment.CurrentDirectory + @"\DragonRoarAndFire.wav";
                                dragon.Play();
                                graphic.SpeakBox();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"{p1.Name}: ");
                                Console.SetCursorPosition(2, 2);
                                Console.WriteLine("You hear a very loud roar! Its to dark to see,");
                                Console.SetCursorPosition(2, 3);
                                Console.WriteLine("I need something to light up the caves. Maybe I should");
                                Console.SetCursorPosition(2, 4);
                                Console.WriteLine($"go to the {tev.AreaName} to find some information.");
                                Console.ReadKey();

                            }


                            townMusic.PlayLooping();
                        break;
                    case 6:
                            Console.SetCursorPosition(2, 8);
                        Console.WriteLine("Thanks for Playing");
                            Console.SetCursorPosition(2, 10);
                        break;
                    default:
                        break;
                }


                }


                else
                {
                    Console.SetCursorPosition(2, 10);
                   Console.WriteLine("Invalid Input! Please enter in between 1 - 6");
                    Console.ReadKey();
                }


            } while (userInput != 6);

        }

  


        }
  }

