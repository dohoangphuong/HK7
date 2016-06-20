using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeAttack
{
    class Drone: Bee
    {
        /// <summary>
        /// the constructor of class
        /// </summary>
        public Drone()
        {
            bytBeeType = 2;
        }

        /// <summary>
        /// override method Damage from Bee
        /// </summary>
        public override void Damage(int dame)
        {
            if (blnAlive)
            {
                fltHealth = fltHealth - dame;
                if (fltHealth < 50)
                    blnAlive = false;
            }
        }
    }
}
