using EBook.Domain;
using EBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.BussinesLogic.Services
{
    public class CartService : ICartService
    {
        private readonly EBookAppContext _context;
        public CartService(EBookAppContext context)
        {
            _context = context;
        }
        public void AddToCart(string cartId, int productId, int quantity)
        {
            var cartItem = _context.ShoppingCartItems.SingleOrDefault(
    c => c.CartId == cartId && c.ProductId == productId);

            if (cartItem == null)
            {
                // Create a new cart item if it doesn't exist
                cartItem = new Cart
                {
                    ItemId = Guid.NewGuid().ToString(),
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = quantity
                };

                _context.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                // Update the quantity if the cart item already exists
                cartItem.Quantity += quantity;
            }

            _context.SaveChanges();
        }

        public void ClearCart(string cartId)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCart(string cartId, int itemId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCart(string cartId, int itemId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
