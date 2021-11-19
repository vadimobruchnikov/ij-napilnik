using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikTask02
{
    public class Cell
    {
        private readonly Good _good;
        private int _count;

        public Cell(Good good, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (good == null)
                throw new ArgumentNullException(nameof(good));

            _good = good;
            _count = count;
        }

        public Good GetGood()
        {
            return _good;
        }
        public int GetCount()
        {
            return _count;
        }
        public void AddCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            _count += count;
        }
        public void SubCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (count > _count)
                throw new ArgumentOutOfRangeException(nameof(count));

            // Удалять ли ячейку при нулевом остатке?
            // if (count == _count)

            _count -= count;
        }
    }
}
