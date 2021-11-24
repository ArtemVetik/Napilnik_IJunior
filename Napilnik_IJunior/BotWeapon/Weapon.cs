using System;
using System.Collections.Generic;
using System.Text;

namespace Napilnik.BotWeapon
{
    class Weapon
    {
        private int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            if (bullets < 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            _damage = damage;
            _bullets = bullets;
        }

        public void Fire(IDamageable player)
        {
            if (_bullets == 0)
                throw new InvalidOperationException();

            player.Damage(_damage);
            _bullets -= 1;
        }
    }
}
