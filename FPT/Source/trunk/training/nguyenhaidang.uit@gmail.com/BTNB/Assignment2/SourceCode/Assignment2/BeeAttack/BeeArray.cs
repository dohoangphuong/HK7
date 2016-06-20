using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeAttack
{
    class BeeArray
    {
        public const int NUMBER_OF_BEES = 30;

        /// <summary>
        /// array of bees
        /// </summary>
        private Bee[] ArrayBee;
        internal Bee[] ArrBee
        {
            get { return ArrayBee; }
            set { ArrayBee = value; }
        }

        /// <summary>
        /// the constructor of class
        /// </summary>
        public BeeArray()
        { 
            ArrayBee = new Bee[NUMBER_OF_BEES];
        }

        /// <summary>
        /// create bees
        /// </summary>
        public void CreateBees()
        {
            Random rand = new Random();
            for (int i = 0; i < NUMBER_OF_BEES; i++)
            {
                int temp = rand.Next(3);
                switch (temp)
                { 
                    case 0:
                        ArrayBee[i] = new Worker();
                        break;
                    case 1:
                        ArrayBee[i] = new Queen();
                        break;
                    case 2:
                        ArrayBee[i] = new Drone();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// damage bee
        /// </summary>
        public void Damage()
        {
            Random rand = new Random();
            for (int i = 0; i < NUMBER_OF_BEES; i++)
            {
                ArrayBee[i].Damage(rand.Next(80));
                ArrayBee[i].ShowStatus();
            }
        }

        /// <summary>
        /// show status of bee
        /// </summary>
        public void ShowStatus()
        {
            for (int i = 0; i < NUMBER_OF_BEES; i++)
                ArrayBee[i].ShowStatus();
        }
    }
}
