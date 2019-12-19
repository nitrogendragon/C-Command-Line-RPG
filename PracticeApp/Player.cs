using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp
{
    ///<summary>Player(int strength, int speed)</summary> 
    class Player : Stats
    {
        public bool guarding;
        public int guardDurationLeft;

        public Player(int strength, int speed)
        {
            Console.WriteLine("player created");
            SetStats(strength, speed);
            guarding = false;
            guardDurationLeft = 0;
        }

        ~Player()
        {
            Console.WriteLine("You died");
        }

        public override void SetStats(int strength, int speed)
        {
            hp = strength * 30;
            remaininghp = strength * 30;
            def = strength * 2;
            baseDef = strength * 2;
            atk = strength * 5;
            baseAtk = strength * 5;
            spd = speed;
        }
        public int CheckGuardTimeRemaining()
        {
            if(guardDurationLeft>0)
            {
                guardDurationLeft -= 1;
                Console.WriteLine("Your guard will end in {0} turns.", guardDurationLeft);
            }
            return guardDurationLeft;
        }
        public void Attack(ref Enemy enemy)
        {
            if (enemy.def < atk)
            {
                enemy.remaininghp -= atk - def;
                Console.WriteLine("You hit! The enemy only has {0} hp left", enemy.remaininghp);
            }
            else
            {
                Console.WriteLine("You try to strike your opponent but miserably fail.\n" +
                    "You should really go workout some more if you can find a way to survive this.");
            }
        }

        public void Guard()
        {
            guarding = true;
            guardDurationLeft = 3;
            def += (int)(def*.5);
            Console.WriteLine("You tightened your guard up. Your defense is now {0}", def);
        }

        public void EndGuard()
        {
            guarding = false;
            def = baseDef;
            Console.WriteLine("After a tense engagement you relax slightly. Your defense is now {0}", def);
        }

        public void Heal()
        {
            int hplost = hp - remaininghp;
            if (hplost > 7)
            {
                remaininghp += 7;
                Console.WriteLine("It isn't perfect but you managed to fix yourself up a bit.\n" +
                    "You're more prepared for the next engagement" +
                    "You are now at {0}hp",hp);
            }
            else if(hplost==0)
            {
                Console.WriteLine("You chewed on some candy...\n It didn't help you very much.");
            }
            else
            {
                remaininghp = hp;
                Console.WriteLine("You took a deep breath in and channeled your energy. \n" +
                    "You are now Perfectly Prepared for the next engagement");
            }
            
        }

        public int getSpeed()
        {
            return spd;
        }
        public bool StillAlive()
        {
            if(remaininghp>0)
            {
                return true;
            }
            Console.WriteLine("Your journey ends here unfortunately.\n" +
                "If you're lucky you'll meet some attractive mates in the afterlife.");
            return false;
        }
    }
}
