using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PracticeApp
{
    class MainProgram
    {
        public static int Sum(int[] numbers)
        {
            int sum = 0;
            foreach(int item in numbers)
            {
                sum += item;
            }
            return sum;
        }

        
        static void Main(string[] args)
        {

            //ExtraClass c = new ExtraClass();
            //Extender e = new Extender();
            //string str = "Hello";
            //Console.WriteLine("The value of str is {0}", str);
            //string str2 = ExtraClass.ReverseString(str);
            //Console.WriteLine("The value of str is {0}", str2);
            //Console.WriteLine("We will now print the values for c");
            //c.PrintInput(1, 1.2, 'c', "bob", true, 3);
            //Console.WriteLine("We will now print the values for e");
            //e.PrintInput(1, 1.2, 'c', "bob", true, 3);
            //bool alive = true;
            
            Player player = new Player(1, 5);
            Enemy ghoul = new Enemy(1, 3);
            BattleHandler bh = new BattleHandler();

            Console.WriteLine("starting up the battle");
            bh.LoadCombatants(ghoul, player);

            Console.WriteLine("Running the battle logic while both sides still stand");
            while(bh.player.StillAlive() && bh.enemy.StillAlive())
            {
                Console.WriteLine("\nplayer hp  = {0}/{1}", bh.player.remaininghp,bh.player.hp);
                Console.WriteLine("enemy hp  = {0}/{1}\n\n", bh.enemy.remaininghp,bh.enemy.hp);
                bh.runBattleSequence();
                if(bh.player.StillAlive() == false || bh.player.StillAlive() == false)
                {
                    break;
                }
            }
        }
    }
}
