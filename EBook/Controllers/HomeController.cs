using EBook.BussinesLogic.Services;
using EBook.Domain.Entities;
using EBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Primim datele din appsettings.jshon
        //private readonly IConfiguration Configuration;
        private readonly IBookService _service;
        public HomeController(ILogger<HomeController> logger, IBookService service)
        {
            _service = service;
            _logger = logger;
            //Configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Forum()
        {
            return View();
        }

        //public IActionResult Login()
        //{
            // In felul dat primim numele la admin
            //var adminName = Configuration.GetSection("Admin:Name");
            //return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}