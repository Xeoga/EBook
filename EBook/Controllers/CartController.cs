using EBook.BussinesLogic.Services;
using EBook.Domain;
using EBook.Domain.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EBook.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            string cartId = GetCartId();
            _cartService.AddToCart(cartId, id, 1);
            return RedirectToAction("Cart", "ShoppingCart");
        }
        private string GetCartId()
        {
            // Implementați codul pentru a obține identificatorul coșului de cumpărături asociat utilizatorului curent
            // și returnați identificatorul coșului de cumpărături

            // Exemplu:
            // Puteți utiliza HttpContext.Session pentru a stoca și accesa identificatorul coșului de cumpărături în sesiune
            string cartId = HttpContext.Session.GetString("CartId");
            if (cartId == null)
            {
                // Dacă identificatorul coșului de cumpărături nu există în sesiune, generați unul nou și stocați-l în sesiune
                cartId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("CartId", cartId);
            }

            return cartId;
        }
    }
}
