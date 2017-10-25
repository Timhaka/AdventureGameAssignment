using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Models;


namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(@"                _                          _                              _____                            ");
            Console.WriteLine(@"    /\         | |                        | |                            / ____|                           ");
            Console.WriteLine(@"   /  \      __| | __   __   ___   _ __   | |_   _   _   _ __    ___    | |  __    __ _   _ __ ___     ___ ");
            Console.WriteLine(@"  / /\ \    / _` | \ \ / /  / _ \ | '_ \  | __| | | | | | '__|  / _ \   | | |_ |  / _` | | '_ ` _ \   / _ \");
            Console.WriteLine(@" / ____ \  | (_| |  \ V /  |  __/ | | | | | |_  | |_| | | |    |  __/   | |__| | | (_| | | | | | | | |  __/");
            Console.WriteLine(@"/_/    \_\  \__,_|   \_/    \___| |_| |_|  \__|  \__,_| |_|     \___|    \_____|  \__,_| |_| |_| |_|  \___|");
            Console.WriteLine(@"                                                                                                           ");

            Console.WriteLine();
            Console.WriteLine("This is a story about a adventurer that travel to a Hunted town in the land of ivalice.");
            Console.WriteLine("The town have problems with a dragon that have started living in the Dark Caves close to the village.");
            Console.WriteLine("The dragon have been wreaking havoc and this have also resulted in that many monsters ");
            Console.WriteLine("have started appearing in the forest. Its up to you to take care of the monsters and to");
            Console.WriteLine("kill the dragon so that the villagers can have peace again. Good Luck!");
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();

            Graphics graphic = new Graphics();
            
            
            graphic.SpeakBox();
            Console.WriteLine("You enter the deserted town and there is not many");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("villagers around. A big fellow with a large beard");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("is walking forwards you. Maybe he has some more");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("information about this place.");
            //Console.SetCursorPosition(2, 5);

            Console.ReadKey();
            Console.Clear();
            
            Menys.startMeny();
        }
    }
}
