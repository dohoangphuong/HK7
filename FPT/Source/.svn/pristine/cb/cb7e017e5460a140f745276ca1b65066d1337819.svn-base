using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee_Ass2
{
    class QueenBee : Bee
    {
        /// <summary> 
        /// Check the health of the bee to know if it dead or not
        /// </summary>
        /// <returns> 
        /// If health is below 20 set the bee dead = true, otherwise it dead = false
        /// </returns>
        protected override void CheckDead()
        {
            if (GetHealth() < 20)
            {
                Dead = true;
            }
            else
            {
                Dead = false;
            }
        }
    }
}
