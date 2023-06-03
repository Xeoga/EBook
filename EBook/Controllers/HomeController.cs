using EBook.BussinesLogic.Services;
using EBook.Domain;
using EBook.Domain.Entities;
using EBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Primim datele din appsettings.jshon
        //private readonly IConfiguration Configuration;
        private readonly IBookService _service;
        private readonly EBookAppContext _context;
        public HomeController(ILogger<HomeController> logger, IBookService service, EBookAppContext context)
        {
            _service = service;
            _logger = logger;
            _context = context;
            //Configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
           
            if (_context.Books==null)
            {
                return Problem("Entity is free:(");
            }
            var books = from m in _context.Books
                        select m;
            if(!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Name!.Contains(searchString));
            }
            return View(await books.ToListAsync());

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