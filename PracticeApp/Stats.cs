using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp
{
    class Stats
    {
        public int hp, remaininghp, atk, baseAtk, def, baseDef, spd;

        public virtual void SetStats(int strength, int speed)
        {
            hp = strength * 10;
            remaininghp = strength * 10;
            def = strength * 2;
            baseDef = strength * 2;
            atk = strength * 3;
            baseAtk = strength * 3;
            spd = speed;
        }
    }
}
