
// ЗАДАЧА
// Переименуйте метод - https://gist.github.com/HolyMonkey/92e8c9c2f08471e31eceef30da7ea6ad

public static int MakeValidNumber(int a, int b, int c)
{
    if (a < b)
        return b;
    else if (a > c)
        return c;
    else
        return a;
}

// Поток рассуждкний
// Сначала разбираемся что делает метод
// MakeValidNumber(1, 2, 3) => 2
// MakeValidNumber(3, 2, 1) => 1
// MakeValidNumber(3, 2, 4) => 4

// думал, что это выбор максимального значения, тогда бы назвал GetMaxValue()
// но по факту просто некое сравнение поэтому
// называем GetComparedNumber(int a, int b, int c)
// или если это валидация GetValidNumber(int a, int b, int c)

public static int GetComparedNumber(int a, int b, int c)
{
    if (a < b)
        return b;
    else if (a > c)
        return c;
    else
        return a;
}