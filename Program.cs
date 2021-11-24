
// ЗАДАЧА 20 Группировка полей по префиксу

// Поправьте код - https://gist.github.com/HolyMonkey/228d407270b740387bbab0fede8fc29b

class Weapon
{
    public float Cooldown { get; private set; }
    public int Damage { get; private set; }

    public bool IsReloading()
    {
        throw new NotImplementedException();
    }
}

class Movement
{
    public float DirectionX { get; private set; }
    public float DirectionY { get; private set; }
    public float Speed { get; private set; }
}

class Player
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    private Movement Movement;
    private Weapon Weapon;

    public void Move()
    {
        //Do move
    }

    public void Attack()
    {
        //attack
    }
}
