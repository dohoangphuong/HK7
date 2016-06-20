using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeAttack
{
    class Queen: Bee
    {
        /// <summary>
        /// the constructor of class
        /// </summary>
        public Queen()
        {
            bytBeeType = 1;
        }

        /// <summary>
        /// override method Damage from Bee
        /// </summary>
        public override void Damage(int dame)
        {
            if (blnAlive)
            {
                fltHealth = fltHealth - dame;
                if (fltHealth < 20)
                    blnAlive = false;
            }
        }
    }
}
