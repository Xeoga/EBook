using Microsoft.AspNetCore.Mvc;
using EBook.BussinesLogic.Services;
using EBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
namespace EBook.Controllers
{
    public class PublishingHouseController : Controller
    {
        private readonly IPublishingHouse _service;
        public PublishingHouseController(PublishingHouseService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult AddHouse() => View();
        [HttpGet]
        public async Task<IActionResult> PIndex()
        {
            var publishingH = await _service.GetAll();
            return View(publishingH);
            //return View();
        }

        
    }
}
