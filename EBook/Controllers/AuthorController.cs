using EBook.BussinesLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }
        // GET: AuthorController
        public async Task<IActionResult> AIndex()
        {
            var authors = await _service.GetAll();
            return View(authors);
        }
    }
}
