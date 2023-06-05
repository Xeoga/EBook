using EBook.BussinesLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ICategorieService _service;
        public CategorieController(ICategorieService service)
        {
            _service = service;
        }
        public async Task<IActionResult> CIndex()
        {
            var data = await _service.GetAll();
            return View(data);
        }
    }
}
