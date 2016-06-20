
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeAttack
{
    abstract class Bee
    {
        /// <summary>
        /// health of bee
        /// </summary>
        protected float fltHealth;
        public float Health
        {
            get { return fltHealth; }
            set { fltHealth = value; }
        }

        /// <summary>
        /// variable defines if the bee is alive or not
        /// </summary>
        protected bool blnAlive;
        public bool Alive
        {
            get { return blnAlive; }
            set { blnAlive = value; }
        }

        /// <summary>
        /// variable defines what type of bee
        /// 0 is Worker, 1 
        /// </summary>
        protected byte bytBeeType;
        public byte BeeType
        {
            get { return bytBeeType; }
            set { bytBeeType = value; }
        }

        /// <summary>
        /// the constructor of class
        /// </summary>
        public Bee()
        {
            fltHealth = 100.0f;
            blnAlive = true;
        }

        /// <summary>
        /// the bee is damaged and bee's health reduces
        /// </summary>
        public abstract void Damage(int dame);

        /// <summary>
        /// show health status of bee
        /// </summary>
        public void ShowStatus()
        {
            switch (bytBeeType)
            { 
                case 0:
                    Console.Write("Worker - ");
                    break;
                case 1:
                    Console.Write("Queen - ");
                    break;
                case 2:
                    Console.Write("Drone - ");
                    break;
                default:
                    Console.Write("Unknown - ");
                    break;
            }
            if (blnAlive)
                Console.Write("Alive - ");
            else
                Console.Write("Dead - ");
            Console.WriteLine(fltHealth);
        }
    }
}
