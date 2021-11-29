using System;
using System.Collections.Generic;
using System.Linq;

// ЗАДАЧА ЗАМЕНА УСЛОВНОЙ ЛОГИКИ ПОЛИМОРФИЗМОМ

// Сейчас система не готова к расширению. 
// К сожалению при добавление нового способа оплаты, 
// нам нужно модифицировать все ифы которые совершают те или иные действия с разными системами.
// Необходимо зафиксировать интерфейс платежёной системы и сокрыть их многообразие под какой-нибудь сущностью. 
// Например фабрикой (или фабричным методом).
// Важное условие: пользователь вводит именно идентификатор платёжной системы.
// https://gist.github.com/HolyMonkey/14f78ed72bda289980fce43f50143278

namespace IMJunior
{
    public class PaymentSystem 
    {
        public string Name { get; private set; }
        public string CallStr { get; private set; }
        public string CheckStr { get; private set; }

        public PaymentSystem(string _name, string _checkStr, string _callStr)
        {
            Name = _name;
            CallStr = _callStr;
            CheckStr = _checkStr;
        }
    }

    class Program
    {
        static void Main()
        {
            // Вместро строк можно вставить call-back функции обработчики платежных систем
            PaymentSystem qiwi = new PaymentSystem("QIWI", "Перевод на страницу QIWI...", "Проверка платежа через QIWI...");
            PaymentSystem webMoney = new PaymentSystem("WebMoney", "Вызов API WebMoney...", "Проверка платежа через WebMoney...");
            PaymentSystem card = new PaymentSystem("Card", "Вызов API банка эмитера карты Card...", "Проверка платежа через Card...");

            PaymentHandler paymentHandler = new PaymentHandler();
            paymentHandler.Systems.Add(qiwi);
            paymentHandler.Systems.Add(webMoney);
            paymentHandler.Systems.Add(card);

            var orderForm = new OrderForm();
            var systemId = orderForm.ShowForm(paymentHandler);

            paymentHandler.SetSystemByName(systemId);
            paymentHandler.CheckAPISystem();
            paymentHandler.CheckPayment();
            paymentHandler.ShowPaymentResult();
        }
    }

    public class OrderForm
    {
        public string ShowForm(PaymentHandler paymentHandler)
        {
            Console.WriteLine($"Мы принимаем: {paymentHandler.GetSystemNames()}");

            //симуляция веб интерфейса
            Console.WriteLine("Какое системой вы хотите совершить оплату?");
            return Console.ReadLine();
        }
    }

    public class PaymentHandler
    {
        public List<PaymentSystem> Systems;
        public PaymentSystem CurrentSystem;

        public PaymentHandler()
        {
            Systems = new List<PaymentSystem>();
        }
        public void SetSystemByName(string name)
        {
            CurrentSystem = Systems.Find(item => item.Name == name);
            if (CurrentSystem == null)
                throw new InvalidOperationException("Неправильный идентификатор системы оплаты!");
        }

        public string GetSystemNames()
        {
            // Вывод принимающих систем через запятую
            return string.Join(", ", Systems.Select(x => x.Name).ToArray());
        }
        public void ShowPaymentResult()
        {
            Console.WriteLine($"Вы оплатили с помощью " + CurrentSystem.Name);
            Console.WriteLine("Оплата прошла успешно!");
        }
        public void CheckAPISystem()
        {
            // Ф-я проверки доступности системы
            Console.WriteLine(CurrentSystem.CallStr);
        }
        public void CheckPayment()
        {
            // Ф-я проверки платежа в системе
            Console.WriteLine(CurrentSystem.CheckStr);
        }
    }
}
