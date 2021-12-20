﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Napilnik1
{
    public class Weapon
    {
        private readonly int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            _damage = damage;

            if (bullets < 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            _bullets = bullets;
        }

        private bool CanFire()
        {
            if (_damage < 0)
                throw new ArgumentOutOfRangeException("Отрицательный дамаг");

            if (_bullets < 0)
                throw new ArgumentOutOfRangeException("Отрицательное значение пуль");

            return (_damage > 0) && (_bullets > 0);
        }

        public void Fire(Player player)
        {
            if (CanFire())
            {
                _bullets -= 1;
                player.TakeDamage(_damage);
            }
            else {
                throw new InvalidOperationException("Невозможно выстрелить");
            }
        }
    }
}
