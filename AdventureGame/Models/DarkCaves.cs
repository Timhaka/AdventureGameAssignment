using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace AdventureGame.Models
{
    class DarkCaves : Areas
    {

        public Boss lastBoss { get; set; }
        Graphics graphic { get; set; }
        public DarkCaves()
        {
            this.AreaName = "The Dark Caves";
            battle = new BattleMeny();
            lastBoss = new Boss("Dragon", 150, 250, 2000, 250, 500);
            lastBoss.AttackName = "Dragon Breath";
            
            
        }

        public void EnterDarkCaves(Player user, Store shop)
        {
            SoundPlayer CaveMusic = new SoundPlayer();
            CaveMusic.SoundLocation = Environment.CurrentDirectory + @"\CavesOfSorrow.wav";
            CaveMusic.PlayLooping();
            this.p1 = user;
            int answer = 0;

            do
            {
                Console.Clear();
                graphic = new Graphics();
                graphic.WritePlayerBox();
                graphic.PlayerInfo(p1);
                graphic.SpeakBox();
                Console.ForegroundColor = ConsoleColor.Magenta;
                
                Console.WriteLine("Where should I go");
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("1. Dragons Lair");
                Console.SetCursorPosition(2, 3);
                Console.WriteLine("2. Go back to Town");
                Console.SetCursorPosition(2, 4);
                string caveAnswer = Console.ReadLine();

                bool result = Int32.TryParse(caveAnswer, out answer);
                if (result)
                {
                    switch (answer)
                    {
                        case 1:
                            SoundPlayer dragon = new SoundPlayer();
                            dragon.SoundLocation = Environment.CurrentDirectory + @"\DragonRoarAndFire.wav";
                            dragon.Play();
                            Console.ReadKey();
                            Console.SetCursorPosition(2, 6);
                            Console.WriteLine("BOSS BATTLE!!!");
                            battle.EnterBattle(user, lastBoss, shop);
                            break;
                        case 2:
                            break;

                        default:
                            break;
                    }
                }

            } while (answer != 2);
        }
    }
}
