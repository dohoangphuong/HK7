using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass02
{
    class CQueen : CBee
    {
        public CQueen()
        {
            typeBee = 2;
        }
        public override void Damage(int iHealth)
        {
            if (iHealth < 0 || iHealth > 100)
            {
                Console.WriteLine("Incorrect value(0-100)");
            }
            else
            {
                if (ALive)
                {
                    healthProperty -= iHealth;
                    if (healthProperty < 20)
                        ALive = false;
                }
            }
        }
    }
}
