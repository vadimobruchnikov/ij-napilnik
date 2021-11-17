using System;
using System.Collections.Generic;
using System.Text;

namespace Napilnik1
{
    public class Bot
    {
        public Weapon Weapon;

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }
}
