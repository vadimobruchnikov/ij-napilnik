using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    abstract class LogWriter
    {
        public List<DayOfWeek> Days { get; private set; }

        public LogWriter(List<DayOfWeek> days)
        {
            Days = days;
        }

        protected abstract void Write(string message);

        public void WriteError(string message)
        {
            if (Days.Any(day => day == DateTime.Now.DayOfWeek))
            {
                Write(message);
            }
        }
    }
}
