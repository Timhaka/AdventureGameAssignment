using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventureGame.Models
{
    class Forest : Areas
    {
        public ForestGuardian Kain { get; set; }

        public List<Monsters> MonsterList { get; set; }
        public Graphics graphic { get; set; }

        public Random SelectMonster { get; set; }

        public Forest()
        {
            this.AreaName = "Evil Forest";
            Kain = new ForestGuardian();
            battle = new BattleMeny();
            MonsterList = new List<Monsters>
            {

                //low monsters
                new Goblin("Green Goblin", 1, 6, 25, 3, 10),
                new Goblin("Evil Goblin", 1, 16, 40, 10, 20),
                new Goblin("Green Goblin", 1, 6, 25, 3, 10),
                new Goblin("Dark Goblin", 1, 12, 35, 8, 15),
                new Goblin("Dark Goblin", 1, 12, 35, 8, 15),
                new Goblin("Evil Goblin", 1, 16, 40, 10, 20),
                new Goblin("Green Goblin", 1, 6, 25, 3, 10),
                new Goblin("Dark Goblin", 1, 12, 35, 8, 15),
                new Goblin("Evil Goblin", 1, 16, 40, 10, 20),
                //Medium Monsters
                new Ogre("Ogre", 14, 25, 80, 20, 30),
                new Ogre("Darkspawn Ogre", 20, 35, 100, 20, 50),
                new Ogre("Ogre", 14, 25, 80, 20, 30),
                new Ogre("Darkspawn Ogre", 20, 35, 100, 20, 50),
                new Ogre("Ogre", 14, 25, 80, 20, 30),
                new Ogre("Darkspawn Ogre", 20, 35, 100, 20, 50),
                //high monsters
                new ForestReapers("Creeper", 25, 45, 125, 35, 95),
                new ForestReapers("Forest Reaper", 35, 50, 150, 50, 100),
                new ForestReapers("Forest Crawler", 30, 40, 170, 60, 120),
                new ForestReapers("Creeper", 25, 45, 125, 35, 95),
                new ForestReapers("Forest Reaper", 35, 50, 150, 50, 100),
                new ForestReapers("Forest Crawler", 30, 40, 170, 60, 120),

                new Boss("Hydra", 80, 100, 1000, 150, 200)
            };

        }
        public void EnterForest(string name, Player user, Store shop)
        {
            graphic = new Graphics();
            System.Media.SoundPlayer forestmusic = new System.Media.SoundPlayer();
            forestmusic.SoundLocation = Environment.CurrentDirectory + @"\InTheForest.wav";

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            graphic.SpeakBox();
            Console.WriteLine("Kain:");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(Kain.SayHello(name));
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Please be careful in the forest! There are many dangerous");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("monsters here. I would advice you to stay away");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("from the waterfall. Many strong monsters lives there");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("and I heard people say they seen the Hydra there.");
            Console.ReadKey();
            this.p1 = user;

            int countLow = 0;
            int countMed = 0;
            int countHigh = 0;
            


            int answer = 0;

            do
            {
                forestmusic.PlayLooping();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                
                
                graphic.WritePlayerBox();
                graphic.PlayerInfo(p1);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                graphic.SpeakBox();
                Console.WriteLine("Where should I go");
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("1. Entrance (Low Level Monsters)");
                Console.SetCursorPosition(2, 3);
                Console.WriteLine("2. Pathway (Mid Level Monsters)");
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("3. Waterfall (High Level Monsters)");
                Console.SetCursorPosition(2, 5);
                Console.WriteLine("4. Go back to Town");
                Console.SetCursorPosition(2, 6);

                string forestAnswer = Console.ReadLine();

                bool result = Int32.TryParse(forestAnswer, out answer);
                if (result && answer <= 4)
                {
                    
                    SelectMonster = new Random();
                    int low = SelectMonster.Next(0, 8);
                    int med = SelectMonster.Next(9, 14);
                    int high = SelectMonster.Next(15, 20);


                    switch (answer)
                    {
                        case 1:
                            battle.EnterBattle(p1, MonsterList[low], shop);
                            countLow++;
                            Console.ReadKey();
                            break;
                        case 2:
                            battle.EnterBattle(p1, MonsterList[med], shop);
                            countMed++;
                            Console.ReadKey();
                            break;
                        case 3:
                            if (countLow >= 5 && countMed >= 5 && countHigh >= 5)
                            {
                                Console.SetCursorPosition(2, 6);
                                Console.WriteLine("BOSS BATTLE!!!");
                                battle.EnterBattle(p1, MonsterList[21], shop);

                                countLow = 0;
                                countMed = 0;
                                countHigh = 0;

                                break;
                            }
                            else
                                battle.EnterBattle(p1, MonsterList[high], shop);
                            countHigh++;

                            Console.ReadKey();
                            break;
                        case 4:
                            System.Media.SoundPlayer townMusic = new System.Media.SoundPlayer();
                            townMusic.SoundLocation = Environment.CurrentDirectory + @"\TownTheme.wav";
                            townMusic.PlayLooping();
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("Invalid Input! Please enter in between 1 - 4");
                    Console.ReadKey();
                }
            } while (answer != 4);
        }


     
    }



}
