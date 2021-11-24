using System;
using System.Collections.Generic;
using System.Text;

namespace Napilnik.BotWeapon
{
    class Player : IDamageable
    {
        public Player(int health)
        {
            if (health < 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            Health = health;
        }

        public int Health { get; private set; }
        public bool Dead => Health == 0;

        public void Damage(int value)
        {
            if (Dead)
                throw new InvalidOperationException();
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            Health -= value;

            if (Health < 0)
                Health = 0;
        }
    }
}
