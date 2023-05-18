using EBook.BussinesLogic.Services;
using EBook.Domain.Entities;
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
        [HttpGet]
        public IActionResult AddAuthor() => View();
        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author model)
        {
            //if (ModelState.IsValid)
            //{
                await _service.AddAuthor(model);
                //return View(AIndex);
                return RedirectToAction(nameof(AIndex));
            //}
            //return View();
        }
        // GET: AuthorController
        [HttpGet]
        public async Task<IActionResult> AIndex()
        {
            var authors = await _service.GetAll();
            return View(authors);
        }
      
    }
}
// https://i1.wp.com/lit216.pbworks.com/f/1403891708/frank-herbert.jpg
// Frank Herbert
// October 8, 1920