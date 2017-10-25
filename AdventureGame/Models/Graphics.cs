using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class Graphics
    {
        public void WritePlayerBox()
        {

            Console.SetCursorPosition(80, 0);

            Console.ForegroundColor = ConsoleColor.Gray;
            WriteLineKeepPos("---------------------------------");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos("---------------------------------");
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.White;


        }

        public void SpeakBox()
        {
            Console.SetCursorPosition(0, 0);


            WriteLineKeepPos("----------------------------------------------------------------");
            WriteLineKeepPos($"|                                                              |");
            WriteLineKeepPos($"|                                                              |");
            WriteLineKeepPos($"|                                                              |");
            WriteLineKeepPos($"|                                                              |");
            WriteLineKeepPos($"|                                                              |");
            WriteLineKeepPos($"|                                                              |");
            WriteLineKeepPos($"|                                                              |");
            WriteLineKeepPos($"|                                                              |");
            WriteLineKeepPos("----------------------------------------------------------------");
            Console.SetCursorPosition(2, 1);


        }


        public void WriteMonsterBox()
        {

            Console.SetCursorPosition(80, 12);


            WriteLineKeepPos("---------------------------------");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos("---------------------------------");
            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void BattleInformation()
        {

            Console.SetCursorPosition(0, 10);


            WriteLineKeepPos("---------------------------------");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos("---------------------------------");
            Console.SetCursorPosition(2, 11);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WinInformation()
        {

            Console.SetCursorPosition(0, 18);


            WriteLineKeepPos("---------------------------------");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos("---------------------------------");
            Console.SetCursorPosition(2, 19);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LevelInformation()
        {

            Console.SetCursorPosition(40, 0);

            
            WriteLineKeepPos("---------------------------------");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos($"|                               |");
            WriteLineKeepPos("---------------------------------");
            Console.SetCursorPosition(43, 2);

            Console.ForegroundColor = ConsoleColor.White;

          
        }


        public void PlayerInfo(Player n)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(82, 0);
            WriteLineKeepPos("");
            WriteLineKeepPos($"Level: { n.Level}");
            WriteLineKeepPos($"Name: { n.Name}");
            WriteLineKeepPos($"HP: {n.HP}/{n.MaxHP}  Exp: {n.EXP}");
            WriteLineKeepPos($"Gil: {n.Gil}");
            WriteLineKeepPos($"Weapon: {n.Weapon.Name}");
            WriteLineKeepPos($"Armor: {n.Armor.Name}");
            WriteLineKeepPos($"Shield: {n.Shield.Name}");

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PlayerStats(Player n)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(82, 0);
            WriteLineKeepPos("");
            WriteLineKeepPos($"Player Stats");
            WriteLineKeepPos($"Level: { n.Level}       ");
            WriteLineKeepPos($"HP: {n.HP}/{n.MaxHP}  Exp: {n.EXP}");
            WriteLineKeepPos($"Gil: {n.Gil}  ");
            WriteLineKeepPos($"Strenght: {n.Strenght}  ");
            WriteLineKeepPos($"Vitality: {n.Vitality}  ");
            WriteLineKeepPos($"");

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MonsterInfo(Monsters monst)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(85, 12);
            WriteLineKeepPos("");
            WriteLineKeepPos($"Name: {monst.Name}");
            WriteLineKeepPos($"HP: {monst.HP}/{monst.MaxHP}");
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void WriteLineKeepPos(string text)
        {
            int top = Console.CursorTop;
            int left = Console.CursorLeft;

            Console.WriteLine(text);
            Console.SetCursorPosition(left, top + 1);

        }


    }
}
