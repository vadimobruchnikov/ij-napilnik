using System;
using System.Collections.Generic;

namespace Task03
{
    class ConsoleLogWriter : LogWriter, ILoger
    {
        public new List<DayOfWeek> Days { get; private set; }

        public ConsoleLogWriter(List<DayOfWeek> days): base(days)
        {
            Days = days;
        }

        protected override void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
