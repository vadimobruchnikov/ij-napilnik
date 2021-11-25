using System;
using System.Collections.Generic;
using System.Text;

namespace Napilnik1
{
    public class Player
    {
        private int _health;
        public bool CanDamaged() => _health > 0;

        public Player(int health)
        {
            // Если только мы не пишем игру про зомби
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            _health = health;
        }
        
        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (CanDamaged())
            {
                _health -= damage;
            }
        }
    }

}
