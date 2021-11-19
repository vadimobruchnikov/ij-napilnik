using System;

namespace Napilnik1
{
    class Program
    {
        static void Main()
        {

            Weapon weaponMP5 = new Weapon(15, 10);

            Bot bot = new Bot(weaponMP5);

            Player player = new Player(120);

            // bot нашел player
            bot.OnSeePlayer(player);

        }
    }
}
