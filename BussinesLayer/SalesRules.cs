using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    internal class SalesRules
    {
        public bool IsStockAvailable(Product product, int quantity)
        {
            // Implementarea logicii de verificare a stocului disponibil
            return product.StockQuantity >= quantity;
        }

        public bool IsPaymentCompleted(Order order)
        {
            // Implementarea logicii de verificare a statutului de plată al comenzii
            return order.PaymentStatus == PaymentStatus.Completed;
        }

        public bool HasAdminPrivileges(User user)
        {
            // Implementarea logicii de verificare a privilegiilor de utilizator
            return user.Role == UserRole.Admin;
        }
    }
}
