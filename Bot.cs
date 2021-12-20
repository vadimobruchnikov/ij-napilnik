using System;
using System.Collections.Generic;
using System.Text;

namespace Napilnik1
{
    public class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            if (weapon == null)
                throw new NullReferenceException(nameof(weapon));

            _weapon = weapon;    
        }

        public void OnSeePlayer(Player player)
        {
            if (player == null)
                throw new NullReferenceException(nameof(player));

            _weapon.Fire(player);
        }
    }
}
