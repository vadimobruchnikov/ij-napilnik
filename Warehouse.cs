using System;
using System.Collections.Generic;
using System.Linq;

namespace NapilnikTask02
{
    public class Warehouse
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
        public int GetGoodCount(Good good)
        {
            Cell Item = _storage.FirstOrDefault(cell => cell.GetGood() == good);

            if (Item == null)
                return 0;
            else
                return Item.GetCount();

        }
        public List<Cell> GetStorage()
        { 
            return _storage;
        }
    }
}
