using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  Задача Task03  -  Есть такая реализация логирования - https://pastebin.com/7xL6S4vV

    Защищённый логер SecureConsoleLogWriter даёт функционал, что логер пишется только по пятницам (такая условность).

    Представьте класс Pathfinder у которого есть зависимость от условного ILoger, в процессе своей работы он что-то пишет в лог. 
    Что не принципиально. Сделайте в нём один метод Find который только пишет в лог через своего логера.

    Перепроектируйте систему логирования так, что бы у меня было 5 объектов класса Pathfinder. 
    1) Пишет лог в файл. 2) Пишет лог в консоль. 3) Пишет лог в файл по пятницам. 4) Пишет лог в консоль по пятницам. 5) Пишет лог в консоль а по пятницам ещё и в файл.

 */

namespace Task03
{
    class Program
    {
        static void Main()
        {
            List<DayOfWeek> everyDays = new List<DayOfWeek> { 
                DayOfWeek.Monday, 
                DayOfWeek.Tuesday, 
                DayOfWeek.Wednesday, 
                DayOfWeek.Thursday, 
                DayOfWeek.Friday, 
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };

            List<DayOfWeek> friday = new List<DayOfWeek> { DayOfWeek.Friday };

            Pathfinder pathfinder1 = new Pathfinder(new FileLogWriter(everyDays));
            pathfinder1.WriteError("Error message #1");

            Pathfinder pathfinder2 = new Pathfinder(new ConsoleLogWriter(everyDays));
            pathfinder2.WriteError("Error message #2");

            Pathfinder pathfinder3 = new Pathfinder(new FileLogWriter(friday));
            pathfinder3.WriteError("Error message #3");

            Pathfinder pathfinder4 = new Pathfinder(new ConsoleLogWriter(friday));
            pathfinder4.WriteError("Error message #4");

            Pathfinder pathfinder5 = new Pathfinder(new ConsoleLogWriter(everyDays), new FileLogWriter(friday));
            pathfinder5.WriteError("Error  message #5");
        }
    }
}