using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class BeeDrone : Bee
    {
        public override void IsDead()
        {
            if (Health < 50) Status = "Dead";
            else Status = "Alive";
        }

    }
}
