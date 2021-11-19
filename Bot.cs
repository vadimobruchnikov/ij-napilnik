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
            _weapon = weapon;    
        }

        public void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}
