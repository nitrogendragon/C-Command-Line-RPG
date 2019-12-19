using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp
{
    class Enemy : Stats
    {
        public bool guarding;
        public int guardDurationLeft;

        public Enemy(int strength, int speed)
        {
            Console.WriteLine("enemy created");
            SetStats(strength, speed);
            guarding = false;
            guardDurationLeft = 0;
        }

        ~Enemy()
        {
            Console.WriteLine("The enemy died");
        }

        public int CheckGuardTimeRemaining()
        {
            if (guardDurationLeft > 0)
            {
                guardDurationLeft--;
                Console.WriteLine("The enemies guard will end in {0} turns.",guardDurationLeft);
            }
            return guardDurationLeft;
        }

        public void Attack(ref Player player)
        {
            if (player.def < atk)
            {
                player.remaininghp -= atk-def;
                Console.WriteLine("Your opponent finds an opening and hits cleanly.\n" +
                    "Your hp falls to {0}.",player.remaininghp);
            }
            else
            {
                Console.WriteLine("Your opponents tries to stab you but fails.\n" +
                    "Your heavenly titanium body repels the attack.");
            }
        }

        public void Guard()
        {
            guarding = true;
            guardDurationLeft = 3;
            Console.WriteLine("Your opponent tightens its guard up. \n" +
                "There doesn't seem to be much of a chance of getting a good hit in now.");
            def = (int)(def * 1.5);
        }

        public void RushAttack(ref Player player)
        {
            player.remaininghp -= atk;
            Console.WriteLine("Your opponent surprises you with a rushing charge!? \n" +
                "You couldn't even try to defend yourself as your hp falls to {0}.", player.remaininghp);
        }

        public void EndGuard()
        {
            guarding = false;
            Console.WriteLine("Your opponent has loosened its guard up. Maybe we should poke it now?");
            def = baseDef;
        }

        public int getSpeed()
        {
            return spd;
        }

        public bool StillAlive()
        {
            if (remaininghp > 0)
            {
                return true;
            }
            Console.WriteLine("You conquered your foe!\n" +
                "Your journey is just beginning....\n" +
                "Or so it would be if the developer had time.\n" +
                "Unfortunately this is the end for you.\n" +
                "Perhaps in another version you will get to slay dragons and reap many rewards\n" +
                "with a long and compelling story line... For now however, congratulations are in order\n" +
                "Do your celebrating and then go be productive.");
            return false;
        }
    }
}
