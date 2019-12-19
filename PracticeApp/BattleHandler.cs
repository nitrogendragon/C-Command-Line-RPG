using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp
{
    class BattleHandler : DecisionMaking
    {
        public static bool enemyfirst;
        public Enemy enemy;
        public Player player;

        public void DisplayActions()
        {
            Console.WriteLine("               Actions \n" +
                              "Press the correlating key then press Enter\n\n" +
                " AWSD to move pointlessly   1 to attack \n\n" +
                " 2 to guard                 3 to heal");
        }

        public void Act(ref Enemy e, ref Player p)
        {
            while (true)
            {
                DisplayActions();
                string input = Console.ReadLine();
                Console.Clear();
                if (input.ToLower().Trim() == "a")
                {
                    
                    Console.WriteLine("You dodge to the left and...");
                    break;
                }
                else if (input.ToLower().Trim() == "s")
                {
                    Console.WriteLine("You cower before the presence of your enemy and move back a ways and...");
                    break;
                }
                else if (input.ToLower().Trim() == "d")
                {
                    Console.WriteLine("You dodge to the right and...");
                    break;
                }
                else if (input.ToLower().Trim() == "w")
                {
                    Console.WriteLine("Fearing nothing, you dash forward and...");
                    break;
                }
                else if (input.Trim() == "1")
                {
                    //attack the enemy
                    p.Attack(ref e);
                    break;
                }
                else if (input.Trim() == "2")
                {
                    //raise your guard
                    p.Guard();                   
                    break;
                }
                else if (input.Trim() == "3")
                {
                    //heal yourself
                    p.Heal();
                    break;
                }
                else
                {
                    
                }
            }
        }
        public BattleHandler()
        {
            Console.WriteLine("Battle handling ready");
        }

        public void LoadCombatants(Enemy e,Player p)
        {
            enemy = e;
            player = p;
        }

        public void DetermineOrder()
        {
            if(enemy.spd > player.spd)
            {
                Console.WriteLine("This one seems to be faster than you. Be wary...\n");
                enemyfirst = true;
            }
            else
            {
                Console.WriteLine("You're definitely faster than your opponent...\n");
                enemyfirst = false;
            }
        }

        public void runBattleSequence()
        {
            int buffTurnsRemaining = 0;
            DetermineOrder();
            Console.WriteLine("");
            if (enemyfirst)
            {
                //Enemy acts
                ChooseEnemyAction(ref enemy, ref player);
                Console.WriteLine("");
                if (player.StillAlive())
                {

                    //Player acts
                    Act(ref enemy, ref player);
                    Console.WriteLine("");
                    enemy.StillAlive();
                }

            }
            else
            {
                //Player acts
                Act(ref enemy, ref player);
                Console.WriteLine("");
                if (enemy.StillAlive())
                {
                    //Enemy acts
                    ChooseEnemyAction(ref enemy, ref player);
                    Console.WriteLine("");
                    player.StillAlive();
                }

            }
            //Check guards
            if(player.guarding)
            {
                buffTurnsRemaining = player.CheckGuardTimeRemaining();
                Console.WriteLine("player buffTurnsRemaining: {0}\n", buffTurnsRemaining);
                if (buffTurnsRemaining == 0) { player.EndGuard(); }
            }
            if (enemy.guarding)
            {
                buffTurnsRemaining = enemy.CheckGuardTimeRemaining();
                //Console.WriteLine("enemy buffTurnsRemaining: {0}\n", buffTurnsRemaining);
                if(buffTurnsRemaining == 0) { enemy.EndGuard(); }
            }
        }
    }
}
