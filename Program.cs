using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Task04
{
    class Program
    {
        static void Main()
        {
            //Выведите платёжные ссылки для трёх разных систем платежа: 
            //pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
            //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
            //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}
            
            Order order = new Order(1234, 200);

            PaymentSystem1 payment1 = new PaymentSystem1();
            Console.WriteLine($"PaySystem1Link : {payment1.GetPayingLink(order)}");

            PaymentSystem2 payment2 = new PaymentSystem2();
            Console.WriteLine($"PaySystem2Link : {payment2.GetPayingLink(order)}");

            PaymentSystem3 payment3 = new PaymentSystem3("SeCrEt-KEY-SyStEm3");
            Console.WriteLine($"PaySystem3Link : {payment3.GetPayingLink(order)}");

            Console.ReadLine();

        }
        public class Order
        {
            public readonly int Id;
            public readonly int Amount;

            public Order(int id, int amount) => (Id, Amount) = (id, amount);
        }

        public interface IPaymentSystem
        {
            public string GetPayingLink(Order order);
        }

        class PaymentSystem1 : IPaymentSystem
        {

            public string GetPayingLink(Order order)
            {
                //pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
                return $"pay.system1.ru/order?amount={order.Amount}RUB&hash={CryptoLib.CreateMD5(order.Id.ToString())}";
            }
        }

        class PaymentSystem2 : IPaymentSystem
        {
            public string GetPayingLink(Order order)
            {
                //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
                return $"order.system2.ru/pay?hash={CryptoLib.CreateMD5(order.Id.ToString() + order.Amount.ToString())}";
            }
        }
        class PaymentSystem3 : IPaymentSystem
        {
            public readonly string SecretKey;

            public PaymentSystem3(string secretKey)
            {
                SecretKey = secretKey;
            }
            public string GetPayingLink(Order order)
            {
                //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}
                return $"system3.com/pay?amount={order.Amount}&curency=RUB&hash={CryptoLib.CreateSHA1(order.Amount.ToString() + order.Id.ToString() + SecretKey)}";
            }
        }
    }
}



