using Microsoft.AspNetCore.Mvc;

namespace EBook.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
