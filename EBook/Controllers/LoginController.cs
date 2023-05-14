using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EBook.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult SingUp()
        {
            return View();
        }
    }
}
