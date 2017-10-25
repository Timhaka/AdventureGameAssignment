using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    class Tavern : Areas
    {
        private TavernNPC Cindy { get; set; }
        public Random HintNumber { get; set; }
        public Tavern()
        {
            this.AreaName = "The old Horse Inn";
            Cindy = new TavernNPC();
            HintNumber = new Random();

        }

        public void EnterTavern(Player p1)
        {
            int answer = 0;
            Graphics graphic = new Graphics();
            graphic.SpeakBox();
            Console.WriteLine("Cindy: ");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(Cindy.SayHello(p1.Name));
            Console.SetCursorPosition(2,3);
            Console.WriteLine("How can I help you?");
            Console.ReadKey();
            do
            {
                
                Console.Clear();
                graphic.WritePlayerBox();
                graphic.PlayerInfo(p1);
                Console.ForegroundColor = ConsoleColor.Gray;
                graphic.SpeakBox();
                Console.WriteLine($"The price to rest is 10 gil. Your Hp is {p1.HP}/{p1.MaxHP}\n");
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("1. Rest");
                Console.SetCursorPosition(2, 3);
                Console.WriteLine("2. Information");
                Console.SetCursorPosition(2, 4);
                Console.WriteLine("3. Exit");
                Console.SetCursorPosition(2, 5);
                string tavernAnswer = Console.ReadLine();

                bool result = Int32.TryParse(tavernAnswer, out answer);
                if (result)
                {
                    switch (answer)
                    {
                        case 1:
                            if (p1.Gil > 9)
                            {
                                Console.SetCursorPosition(2, 6);
                                Console.WriteLine("Thank you sleep well");
                                p1.SpendMoney(10);
                                p1.HP = p1.MaxHP;
                                Console.SetCursorPosition(2, 7);
                                Console.WriteLine("Your HP is now full");
                                Console.ReadKey();
                                
                            }
                            else
                            {
                                Console.SetCursorPosition(2, 6);
                                Console.WriteLine("You do not have Enought gil, Come back again");
                                Console.ReadKey();
                            }


                            break;
                        case 2:
                            Console.SetCursorPosition(2, 6);
                            Cindy.Hint(HintNumber.Next(1, 7));
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.SetCursorPosition(2, 6);
                            Console.WriteLine("Bye Bye!");
                            Console.ReadKey();
                            break;
                        default:
                            break;
                    }
                }


                
            } while (answer != 3);

        }
    }
}
