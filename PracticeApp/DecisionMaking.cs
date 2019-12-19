using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp
{
    class DecisionMaking
    {
        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            return (getrandom.Next(min, max));
        }
        public static void ChooseEnemyAction(ref Enemy e, ref Player p)
        {
            int choice = GetRandomNumber(0, 3);
            switch (choice)
            {
                case 0:
                    e.Attack(ref p);
                    break;
                case 1:
                    e.Guard();
                    break;
                case 2:
                    e.RushAttack(ref p);
                    break;
           
            }
        }

        
    }


}
