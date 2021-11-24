
// ЗАДАЧА 17 Методы Set Должны устанавливать значение из параметра

// Метод Set устанавливает значение через свой параметр, 
// плохая история когда вы под Set маскируете более информативный глагол. 
// Т.е если вы через этот метод не устанавливаете значеие 
// (например метод SetMoney(int amount) который установит значение), 
// то придумайте информативный глагол.

// Попробуйте переназвать эти методы - https://gist.github.com/HolyMonkey/0b7021ff18da43ca46705ca3c6a3dea9

public static void CreateObject()
{
    //Создание объекта на карте
}

public static void SetRandomChance()
{
    _chance = Random.Range(0, 100);
}

public static int CalcSalary(int hoursWorked)
{
    return _hourlyRate * hoursWorked;
}
