using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class BattleMeny 
    {
        
        public KeyItem Key { get; set; }
        public Graphics graphic { get; set; }

        public void EnterBattle(Player p1, Monsters monst, Store shop)
        {
            System.Media.SoundPlayer battleMusic = new System.Media.SoundPlayer();
            System.Media.SoundPlayer bossMusic = new System.Media.SoundPlayer();
            battleMusic.SoundLocation = Environment.CurrentDirectory + @"\BattleInTheForest.wav";
            bossMusic.SoundLocation = Environment.CurrentDirectory + @"\BossBattle.wav";

            graphic = new Graphics();
            bool b = false;
            if (monst is Boss)
            {
                bossMusic.PlayLooping();
            }
            else
            {
                battleMusic.PlayLooping();
            }

            

            int playerInput = 0;
            int keyItemToInv = 0;
            Key = new KeyItem();

            Console.SetCursorPosition(2, 7);
            Console.WriteLine($"You entered a battle with a {monst.Name}!!\n");
            Console.ReadKey();
            do {
                Console.Clear();
                graphic.WritePlayerBox();
                graphic.PlayerInfo(p1);
                graphic.WriteMonsterBox();
                graphic.MonsterInfo(monst);
                
                Random missNumber = new Random();
                Console.WriteLine("------------");
                Console.WriteLine("1. Attack\n2. Items\n3. Escape");
                Console.WriteLine("------------");

                

                string playerAnswer = Console.ReadLine();
                graphic.BattleInformation();
                bool result = Int32.TryParse(playerAnswer, out playerInput);
                if (result && playerInput <=3)
                {

                
                        switch (playerInput)
                        {
                            case 1:
                                
                                int miss = missNumber.Next(1, 18);
                                int gMiss = missNumber.Next(1, 18);

                                if (miss == 2 || miss == 8)
                                {
                                    Console.WriteLine("You miss\n");
                                    Console.ReadKey();
                                }
                               
                                else
                                {
                                    monst.LoseHp(p1.Attack());
                                    System.Media.SoundPlayer sword = new System.Media.SoundPlayer();
                                    sword.SoundLocation = Environment.CurrentDirectory + @"\Sword.wav";
                                    sword.Play();
                                    
                                    Console.WriteLine($"You did {p1.Attack()} damage!\n");
                                    Console.ReadKey();

                                    if (monst is Boss)
                                    {
                                       bossMusic.PlayLooping();
                                    }
                                    else
                                    {
                                        battleMusic.PlayLooping();
                                    }
                                }

                                if (gMiss == 2 || gMiss == 8 && monst.HP > 0)
                                {
                                    Console.SetCursorPosition(2, 13);
                                    Console.WriteLine($"{monst.Name} miss you");
                                    Console.ReadKey();
                                }

                                else if (monst.HP > 0 && gMiss == 5 || gMiss == 3 || gMiss == 12)
                                {
                                    
                                    p1.LoseHp(monst.SpecialAttack());
                                    Console.SetCursorPosition(2, 13);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{monst.AttackName} did {monst.SpecialAttack()} damage!\n");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }

                                else if (monst.HP > 0)
                                {
                                    p1.LoseHp(monst.Attack());
                                    Console.SetCursorPosition(2, 13);
                                    Console.WriteLine($"{monst.Name} did {monst.Attack()} damage!\n");
                                    Console.ReadKey();
                                }
                               

                                if (p1.HP <= 0)
                                {
                                    goto case 5;
                                }
                                else if (monst.HP <= 0)
                                {
                                    p1.EXP += 5;
                                    p1.GainMoney(monst.GilDrop);
                                    goto case 4;
                                }

                                break;
                            case 2:
                                p1.UsePotion();
                                
                                Console.ReadKey();
                                break;
                            case 3:
                                if (monst is Boss)
                                {
                                    Console.WriteLine("you can't run away!\n");
                                    p1.LoseHp(monst.Attack());
                                    Console.SetCursorPosition(2, 13);
                                    Console.WriteLine($"{monst.Name} did {monst.Attack()} damage!\n");
                                    playerInput = 0;
                                    Console.ReadKey();
                                    if (p1.HP <= 0)
                                    {
                                        goto case 5;
                                    }
                                    break;
                                }
                                else if (p1.Attack() < monst.MaxDamage)
                                {
                                    Console.WriteLine("Failed to run away\n");
                                    p1.LoseHp(monst.Attack());
                                    Console.SetCursorPosition(2, 13);
                                    Console.WriteLine($"{monst.Name} did {monst.Attack()} damage!\n");
                                    Console.ReadKey();
                                    playerInput = 0;
                                    if (p1.HP <= 0)
                                    {
                                        goto case 5;
                                    }
                                    break;
                                }
                                
                                else 
                                Console.WriteLine("You run away");
                                break;
                            case 4:
                                if (monst.Name == "Dragon")
                                {
                                    Console.Clear();
                                    graphic.WritePlayerBox();
                                    graphic.PlayerInfo(p1);
                                    graphic.SpeakBox();
                                    Console.WriteLine("Congratulation! You have deafeated the Dragon!");
                                    Console.SetCursorPosition(2,2);
                                    Console.WriteLine("Now the villages will have peace again!");
                                    Console.SetCursorPosition(2, 3);
                                    Console.WriteLine($"The Adventurer {p1.Name} walked out from the Dark Caves.");
                                    Console.SetCursorPosition(2, 4);
                                    Console.WriteLine("All the villages where standing by the entrance,");
                                    Console.SetCursorPosition(2, 5);
                                    Console.WriteLine("they all thanked the adventurer for defeating the dragon");
                                    Console.SetCursorPosition(2, 6);
                                    Console.WriteLine($"{p1.Name} walked away from the village with a smile on");
                                    Console.SetCursorPosition(2, 7);
                                    Console.WriteLine("his face. he walked forwards the horizon thinking");
                                    Console.SetCursorPosition(2, 8);
                                    Console.WriteLine("time to find a new adventure!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.WriteLine($"The village is at peace again after that the adventurer {p1.Name} vanquised the dragon.");
                                    Console.WriteLine("Now they can go back living without being terrorized by the dragon.");
                                    Console.WriteLine("There have also been an decreasement in monsters in the forest.");
                                    Console.WriteLine("It would seem like everything is returning to normal in the village");
                                    Console.WriteLine("The adventurer left the village with hope again.");
                                    Console.WriteLine($"Now {p1.Name} will head for new adventures out in the world of ivalice.");
                                    Console.WriteLine();
                                    Console.WriteLine(@" _____   _   _   _____     _____   _   _   ____  ");
                                    Console.WriteLine(@"|_   _| | | | | | ____|   | ____| | \ | | |  _ \");
                                    Console.WriteLine(@"  | |   | |_| | |  _|     |  _|   |  \| | | | | |");
                                    Console.WriteLine(@"  | |   |  _  | | |___    | |___  | |\  | | |_| |");
                                    Console.WriteLine(@"  |_|   |_| |_| |_____|   |_____| |_| \_| |____/ ");
                                    
                                    
                                    System.Environment.Exit(2); 
                                }
                                else
                                {
                                    graphic.WinInformation();
                                    Console.WriteLine("You Win!");
                                    Console.SetCursorPosition(2, 21);
                                    Console.WriteLine($"You gained {monst.GiveExp()} EXP and {monst.GilDrop} Gil!");
                                    p1.GainXP(monst.GiveExp());
                                    p1.GainLvl(p1);
                                    monst.HP = monst.MaxHP;
                                }
                                // battleMusic.Stop();
                                if (monst is Boss)
                                {
                                    Console.Clear();
                                    // add more story and information about items in store.
                                    graphic.WritePlayerBox();
                                    graphic.PlayerInfo(p1);
                                    graphic.SpeakBox();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("Kain:");
                                    Console.SetCursorPosition(2,2);
                                    Console.WriteLine("WOW you defeated the Hydra! it would seem like");
                                    Console.SetCursorPosition(2, 3);
                                    Console.WriteLine("you gained a Holy Torch, maybe this will help");
                                    Console.SetCursorPosition(15, 3);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Holy Torch, ");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.SetCursorPosition(2, 4);
                                    Console.WriteLine($"you in the Dark Caves? Good Luck on your travels {p1.Name}");
                                    Console.SetCursorPosition(2, 5);
                                    Console.ReadKey();
                                    Console.Clear();

                                    graphic.WritePlayerBox();
                                    graphic.PlayerInfo(p1);
                                    graphic.SpeakBox();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("Kain:");
                                    Console.SetCursorPosition(2, 2);
                                    Console.WriteLine("You should go back to the store I think cid have");
                                    Console.SetCursorPosition(2, 3);
                                    Console.WriteLine("some new items for you!");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(2, 6);
                                    Console.WriteLine("New items avalible in the store!");
                                    Console.ResetColor();
                                    shop.ForestCleared(true);
                                    if (keyItemToInv == 0)
                                    {
                                        p1.AddInventory(Key);
                                        keyItemToInv = 1;
                                    }


                                }

                                Console.ReadKey();
                                playerInput = 10;
                                break;
                            case 5:
                                Console.WriteLine($"The Adventurer {p1.Name} died !!\n Would you like to start over?");
                            
                                Console.WriteLine("1. Yes");
                                Console.WriteLine("2. No");
                                int gameOverAnswer;
                                string gameOver = Console.ReadLine();

                                bool gameOverResult = Int32.TryParse(gameOver, out gameOverAnswer);
                                if (result)
                                {

                                    if (gameOverAnswer == 1)
                                    {
                                        Console.WriteLine("Restarting Game");
                                        Console.ReadKey();
                                        Console.Clear();
                                        battleMusic.Stop();
                                        Menys.startMeny();
                                    }
                                    else if (gameOverAnswer == 2) ;
                                    {
                                        Console.Clear();
                                        Console.WriteLine("The villagers never saw the adventurer again, the only hope for the village is gone!\n");
                                        
                                        Console.WriteLine(@"  ____                                 ___                          _ ");
                                        Console.WriteLine(@" / ___|   __ _   _ __ ___     ___     / _ \  __   __   ___   _ __  | |");
                                        Console.WriteLine(@"| |  _   / _` | | '_ ` _ \   / _ \   | | | | \ \ / /  / _ \ | '__| | |");
                                        Console.WriteLine(@"| |_| | | (_| | | | | | | | |  __/   | |_| |  \ V /  |  __/ | |    |_|");
                                        Console.WriteLine(@" \____|  \__,_| |_| |_| |_|  \___|    \___/    \_/    \___| |_|    (_)");
                                        Console.WriteLine("");
                                        Console.ReadKey();
                                        System.Environment.Exit(1);

                                    }
                                    
                                }
                                else
                                {
                                    goto case 5;
                                }
                                break;

                        }
                    }
                    
                else
                {
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("Invalid Input! Please enter in between 1 - 3");
                    Console.ReadKey();
                }
                }while(playerInput !=3 && playerInput != 10);
            }


        
    }
}
