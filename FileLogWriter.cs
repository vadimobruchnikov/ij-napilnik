using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Task03
{
    class FileLogWriter : LogWriter, ILoger
    {
        public new List<DayOfWeek> Days { get; private set; }

        public FileLogWriter(List<DayOfWeek> days) : base(days)
        {
        }

        protected override void Write(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }
}
