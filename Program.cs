
// ЗАДАЧА 10 Магические числа нужновсегда заменять на константы
// Измените код - https://gist.github.com/HolyMonkey/fece8ba4657cb3583ae74949b252d26a

class Weapon
{
    private int _bullets;

    public bool CanShoot() => _bullets > 0;

    public void Shoot() => _bullets -= 1;
}

// Поток рассуждений 
// Тут что-то странное. И так вроде неплохо смотрится
// Переопределим цифры через константы
// Если я правильно понял условие
// Хотя я бы изменил условие например для дробовика, который стреляет только по 2 патрона MinimalBullets будет 2
// Тогда теоритически можно заменить MinimalBullets в коде на BulletsOnShoot

class Weapon
{

	public const int MinimalBullets = 1;
	public const int BulletsOnShoot = 1;

    private int _bullets;

    public bool CanFire() => _bullets >= MinimalBullets;

    public void Fire() => _bullets -= BulletsOnShoot;
}
