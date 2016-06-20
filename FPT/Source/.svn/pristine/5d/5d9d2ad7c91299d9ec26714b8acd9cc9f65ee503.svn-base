using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass02
{
    abstract class CBee
    {
        protected float healthProperty;
        protected bool aLive;
        protected int typeBee;        

        public float HealthProperty
        {
            get { return healthProperty; }
            set { healthProperty = value; }
        }

        public bool ALive
        {
            get { return aLive; }
            set { aLive = value; }
        }

        public int TypeBee
        {
            get { return typeBee; }
            set { typeBee = value; }
        }

        public CBee()
        {
            healthProperty = 100.0f;
            aLive = true;
        }

        public abstract void Damage(int iHealth);

        public void showHealth()
        {
            switch(typeBee)
            {
                case 1:
                    Console.Write("Worker");
                    break;
                case 2:
                    Console.Write("Queen ");
                    break;
                case 3:
                    Console.Write("Drone ");
                    break;
            }
            if(aLive)
                Console.WriteLine(" - Live - " + healthProperty);
            else
                Console.WriteLine(" - Dead");
        }

        public void showALive()
        {
            switch(aLive)
            {
                case true:
                    Console.Write("Live");
                    break;
                case false:
                    Console.Write("Dead");
                    break;
            }
        }

        public bool getALive()
        {
            return aLive;
        }
    }
}
