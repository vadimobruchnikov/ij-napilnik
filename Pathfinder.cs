using System;

namespace Task03
{
    class Pathfinder : ILoger
    {
        private readonly Array _logers;

        public Pathfinder(params ILoger[] logers)
        {
            _logers = logers;
        }

        private void Find(string message)
        {
            foreach (ILoger loger in _logers)
            {
                loger.WriteError(message);
            }
        }
        public void WriteError(string message)
        {
            Find(message);
        }

    }
}
