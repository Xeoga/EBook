using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
