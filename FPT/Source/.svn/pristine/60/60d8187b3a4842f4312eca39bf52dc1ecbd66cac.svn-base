using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass02
{
    class CWorker : CBee
    {
        public CWorker()
        {
            typeBee = 1;
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
                    if (healthProperty < 70)
                        ALive = false;
                }
            }
        }
    }
}
