using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    internal class SalesProcessor
    {
        public decimal CalculateTotalPrice(decimal price, int quantity, decimal discount)
        {
            // Implementarea logicii de calculare a prețului total
            decimal discountedPrice = price * (1 - discount);
            return discountedPrice * quantity;
        }

        public decimal ApplyTax(decimal totalPrice, decimal taxRate)
        {
            // Implementarea logicii de aplicare a taxelor
            return totalPrice * (1 + taxRate);
        }
    }
}
