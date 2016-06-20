using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ass02_Opt1_Ass01
{
    abstract public class Bee
    {
        private int health;
        // Trạng thái sống chết của ong
        public int Health
        {
            get { return health; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    health = value;
                }
                else
                {
                    health = 100;
                }
            }
        }

        public virtual void Damge(int value)
        {
            if (Health - value < 0)
            {
                Health = 0;
            }
            else
            {
                Health -= value;
            }
        }

        
    }
}
