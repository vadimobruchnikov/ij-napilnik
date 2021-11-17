using System;

namespace Napilnik1
{
    class Program
    {
        static void Main()
        {

            Bot bot = new Bot
            {
                Weapon = new Weapon()
            };

            Player player = new Player();

            // bot нашел player
            bot.OnSeePlayer(player);

        }
    }
}
