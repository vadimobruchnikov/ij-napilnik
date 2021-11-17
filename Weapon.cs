using System;
using System.Collections.Generic;
using System.Text;

namespace Napilnik1
{
    public class Weapon
    {
        public int Damage;
        public int Bullets;

        public void Fire(Player player)
        {
            player.Health -= Damage;

            Bullets -= 1;
        }
    }
}
