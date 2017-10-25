using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class TavernNPC : NPC
    {
      
        public TavernNPC()
        {
            this.Name = "Cindy";
        }
        public override string SayHello(string name)
        {
            return base.SayHello(name) + $"Welcome to the Tavern. My name is {Name}!";
        }

        public void Hint(int x)
        {
            int randomHint = x;

            switch (randomHint)
            {
                case 1:
                    Console.WriteLine("You will have to find the Holy Torch to be");
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("able to enter the Dark Caves.");
                    break;
                case 2:
                    Console.WriteLine("The Hydra slumbers inside the Evil Forest, by defeating a");
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("certain amount of diffrent monsters will awaken the Hydra!");
                    break;
                case 3:
                    Console.WriteLine("The Dragon is inside The Dark Caves!");
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("Be well prepared before facing him!");
                    break;
                case 4:
                    Console.WriteLine("You cant run away from a boss so be careful");
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("if you start a fight with one!");
                    break;
                case 5:
                    Console.WriteLine("I heard Cid might have some new items");
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("avalible if you can kill the Hydra.");
                    break;
                case 6:
                    Console.WriteLine("You will have to defeat 5 low,medium,high");
                    Console.SetCursorPosition(2, 7);
                    Console.WriteLine("monsters to spawn the Boss Hydra.");
                    break;
            }


           
        }
    }
}
