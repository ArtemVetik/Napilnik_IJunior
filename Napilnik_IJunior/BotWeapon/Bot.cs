using System;
using System.Collections.Generic;
using System.Text;

namespace Napilnik.BotWeapon
{
    class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(IDamageable player)
        {
            _weapon.Fire(player);
        }
    }
}
