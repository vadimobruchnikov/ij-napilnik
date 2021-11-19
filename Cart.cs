using System;
using System.Collections.Generic;
using System.Linq;

namespace NapilnikTask02
{
    public class Cart
    {
        private Order _order;
        private readonly List<Cell> _cells;
        private readonly Warehouse _warehouse;
        public Cart(Warehouse warehouse)
        {
            _cells = new List<Cell>();
            
            if (warehouse == null)
                throw new NullReferenceException(nameof(warehouse));

            _warehouse = warehouse;
        }
        public Warehouse GetWarehouse()
        {
            return _warehouse;
        }
        public void Add(Good good, int count)
        {
            int Rest = _warehouse.GetGoodCount(good);
        
            if (Rest < count)
                throw new InvalidOperationException("Нет нужного количества товара на складе");

            Cell newItem = new Cell(good, count);
            Cell Item = _cells.FirstOrDefault(cell => cell.GetGood() == good);

            if (Item == null)
            {
                _cells.Add(newItem);
            }
            else
            {
                Item.AddCount(count);
            }
            _warehouse.Ship(good, count);
        }
        public Order DoOrder(string ordernum)
        {
            _order = new Order(ordernum);

            // TODO: Тут видимо корзину _cells нужно зафиксировать в заказ _order (требуется уточнение ТЗ)
            
            return _order;
        }
        public List<Cell> GetCells()
        {
            // Тут возможно нужно возвращать копию _cells
            return _cells;
        }
    }
}
