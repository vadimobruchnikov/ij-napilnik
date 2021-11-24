
// ЗАДАЧА
// Используйте более распространённое и простое слово в название метода
// https://gist.github.com/HolyMonkey/946002199f327790d8f66e8685a869f3


public static int Rummage(int[] array, int element)
{
	for (int i = 0; i < array.Length; i++)
		if (array[i] == element)
			return i;
	return -1;
}

// Поток рассуждений 
// Посмотрим, что делает этот метод
// Перевод Rummage - рыться
// метод находит индекс первого элемент массива соответствующий числу element
// Странное переопределение метода FindIndex
// Array.FindIndex(array, value => value.Equals(FindValue));
// Ну ок. Допустим в учебных целях. ))
// Тогда Метод должен называться FindIndex() или FindArrayIndex() или просто Find()
// element должен быть переименован в value, т.к. в нем передается искомое значение, ане номер индекса и не элемент

public static int FindIndex(int[] array, int value)
{
    for (int i = 0; i < array.Length; i++)
        if (array[i] == value)
            return i;
    return -1;
}
