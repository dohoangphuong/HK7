using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass02_Opt1_Ass01
{
    public class Drone : Bee
    {
        public override void Damge(int value)
        {
            base.Damge(value);
            if (Health < 50)
            {
                Console.WriteLine("Drone: Dead");
            }
        }
    }
}
