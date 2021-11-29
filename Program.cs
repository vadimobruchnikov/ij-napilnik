
// ЗАДАЧА
//
// Попробуйте заменить метод на пару Включить\Выключить 
// https://gist.github.com/HolyMonkey/ef0c234f158151d80ecb22d3717c9ac2

public void SetPowerOn(bool enable)
{
   _enable = enable;
   _effects.StartEnableAnimation();
}

public void SetPowerOff(bool enable)
{
   _enable = false;
   _pool.Free(this);
}
