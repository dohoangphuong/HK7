using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class BeeQueen : Bee
    {
        public override void IsDead()
        {
            if (Health < 20) Status = "Dead";
           else Status = "Alive";
        }
    }
}
