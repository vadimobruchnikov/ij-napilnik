using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikTask02
{
    public class Shop
    {
        private readonly Warehouse _warehouse;
        private readonly Cart _cart;
        public Shop(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new NullReferenceException(nameof(warehouse));

            _warehouse = warehouse;
            _cart = new Cart(_warehouse);
        }
        public Cart GetCart()
        {
            return _cart;
        }
    }
}
