using System;

namespace NapilnikTask02
{
    class Program
    {
        static void Main()
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            // Прихо товара на склад
            warehouse.Delive(iPhone12, 12);
            warehouse.Delive(iPhone11, 3);

            // Вывод всех товаров на складе с их остатком
            Console.WriteLine(warehouse.ToString());

            Cart cart = shop.GetCart();
            cart.Add(iPhone12, 4);
            cart.Add(iPhone12, 1);
            cart.Add(iPhone11, 1);

            // cart.Add(iPhone11, 3); // при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            // Вывод всех товаров в корзине
            Console.WriteLine(cart.ToString());

            // Вывод всех товаров на складе после бронирования
            Console.WriteLine(warehouse.ToString());

            Console.WriteLine(cart.DoOrder("ORDER-XX-YYY").GetPaylink());
                  
            Console.ReadKey();
        }
    }
}
