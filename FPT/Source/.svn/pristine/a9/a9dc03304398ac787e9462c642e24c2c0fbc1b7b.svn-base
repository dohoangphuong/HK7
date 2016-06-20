using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee_Ass2
{
    abstract class Bee
    {
        private float Health;
        protected bool Dead;

        /// <summary> 
        /// Constructor of Bee class
        /// </summary>
        public Bee()
        {
            Health = 100f;
            Dead = false;
        }

        /// <summary> 
        /// Get current health of the bee
        /// </summary>
        /// <returns> 
        /// Bee's health
        /// </returns>
        public float GetHealth()
        {
            return Health;
        }

        /// <summary> 
        /// Damage the bee's health with a percent
        /// </summary>
        /// <param name="percent">
        /// percent health damage deal to bee current health
        /// </param>
        public void Damage(int percent)
        {
            if (percent >= 0 && percent <= 100)
            {
                if (!Dead)
                {
                    Health -= Health * percent / 100;
                    CheckDead();
                }
            }
            else
            {
                throw new Exception("Damage percent cant be greater than 100% or lower than 0%");
            }
        }

        /// <summary> 
        /// Check the health of the bee to know if it dead or not
        /// </summary>
        abstract protected void CheckDead();

        //Summary: display the current bee infomation in the console windows
        /// <summary> 
        /// display the current bee infomation in the console windows
        /// </summary>
        public void ShowInfomation()
        {
            Console.WriteLine(String.Format("Health: {0 : 0.00}", Health));
        }
    }
}
