using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass2_opt1
{
    class Bee
    {
        protected float _health; // healthy
        protected bool _isDead;

        public Bee()
        {
            _health = 100f;
            _isDead = false;
        }

        /* Set damage to current bee and update health
         * Input: int - damage
         * Output: void
         */
        public virtual void Damage(int damage) 
        {
            // check damage from 0 to 80
            if (damage < 0 || damage > 80)
                throw new Exception("Percentage to reduce health is incorectly. It must be from 0 to 80.");
            // check bee is dead, if bee is dead don't update damage
            if (_isDead)
                return;
            // update damage
            _health -= damage;
            if (_health < 0)
                _health = 0;
        }

        /* Get current health
         * Input: 
         * Output: float
         */
        public float GetHealth()
        {
            return _health;
        }

        /* Check if current be is dead
         * Input: 
         * Output: bool - true: if bee is dead else flase
         */
        public bool IsDead()
        {
            return _isDead;
        }
    }
}
