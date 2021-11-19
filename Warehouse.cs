using System;
using System.Collections.Generic;
using System.Linq;

namespace NapilnikTask02
{
    class Warehouse
    {
        private readonly List<Cell> _storage;
        public Warehouse()
        {
            _storage = new List<Cell>();
        }

        public void Delive(Good good, int count)
        {
            Cell newItem = new Cell(good, count);
            Cell lisItem = _storage.FirstOrDefault(cell => cell.GetGood() == good);

            if (lisItem == null)
                _storage.Add(newItem);
            else
                lisItem.AddCount(count);
        }
        public void Ship(Good good, int count)
        {
            Cell lisItem = _storage.FirstOrDefault(cell => cell.GetGood() == good);

            if (lisItem == null)
                throw new InvalidOperationException("Не найден отгружаемый товар");
            else
                lisItem.SubCount(count);
        }

        internal void PrintRestWarehouse()
        {
            throw new NotImplementedException();
        }

        public int GetGoodCount(Good good)
        {
            Cell Item = _storage.FirstOrDefault(cell => cell.GetGood() == good);

            if (Item == null)
                return 0;
            else
                return Item.GetCount();

        }
        public override string ToString()
        {
            string result = "Склад\n";

            foreach (Cell item in _storage)
            {
                result = result + item.ToString() + "\n";
            }

            return result;
        }
    }
}
