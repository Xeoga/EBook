using EBook.BussinesLogic.Services;
using EBook.Domain.Entities;
using EBook.Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace EBook.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Book model)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(model);
                //return View();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetById(id);
            return View(productDetail);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction();
        }

        public IActionResult AddCategorie()
        {
            return View();
        }

    }
}
