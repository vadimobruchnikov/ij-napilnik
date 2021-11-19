using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikTask02
{
    class Order
    {
        private readonly string _ordernum;
        private readonly string _paylink;
        public Order(string ordernum)
        {
            _ordernum = ordernum;

            // TODO: Тут видемо формируется _paylink ?  Paylink - просто какая-нибудь случайная строка.

            _paylink = $"{_ordernum} : RaNdOmNaYa-StRoKa";
        }

        public string GetPaylink()
        {
            return _paylink;
        }
    }                
}
