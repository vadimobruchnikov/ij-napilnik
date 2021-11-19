using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikTask02
{
    public class Reporter
    {
        public static string Print(Cell cell)
        {
            return $"{cell.GetGood().GetName()} - {cell.GetCount()}";
        }
        public static string Print(Cart cart)
        {
            string result = "Корзина\n";

            foreach (Cell cell in cart.GetCells())
            {
                result = result + Print(cell) + "\n";
            }

            return result;
        }
        public static string Print(Warehouse warehouse)
        {
            string result = "Склад\n";

            foreach (Cell item in warehouse.GetStorage())
            {
                result = result + Print(item) + "\n";
            }

            return result;
        }
    }
}
