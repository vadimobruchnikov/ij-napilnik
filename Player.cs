using System;
using System.Collections.Generic;
using System.Text;

namespace Napilnik1
{
    public class Player
    {
        private int _health;
        public Player(int health)
        {
            _health = health;
        }
        private bool CanDamaged()
        {
            return _health > 0;
        }

        public void TakeDamage(int damage)
        {
            if (CanDamaged())
            {
                _health -= damage;
            }
        }
    }

}
