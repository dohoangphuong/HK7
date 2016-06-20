using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass2_opt1
{
    class DroneBee: Bee
    {
        /* Override method 'Damge(int)' in base class 'Bee' */
        public override void Damage(int damage)
        {
            // update damage
            base.Damage(damage);
            // update bee is dead or alive
            if (_health < 50)
                _isDead = true;
        }
    }
}
