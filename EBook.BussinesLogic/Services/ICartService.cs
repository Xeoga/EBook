using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.BussinesLogic.Services
{
    public interface ICartService
    {
        void AddToCart(string cartId, int productId, int quantity);
        void UpdateCart(string cartId, int itemId, int quantity);
        void RemoveFromCart(string cartId, int itemId);
        void ClearCart(string cartId);
    }
}
