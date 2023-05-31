using Microsoft.AspNetCore.Mvc;
using EBook.BussinesLogic.Services;
using EBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
namespace EBook.Controllers
{
    public class PublishingHouseController : Controller
    {
        //private readonly IPublishingHouse _service;
        //public PublishingHouse(PublishingHouse service)
        //{
            //_service = service;
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
