using EBook.BussinesLogic.Services;
using EBook.Domain.Entities;
using EBook.Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            List<Author> authors = _service.GetAllAuthors();
            ViewBag.Authors = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AuthorBio
            }).ToList();
            ViewBag.Categories = _service.GetCategories();

            List<Categorie> categorie = _service.GetCategories();
            ViewBag.Categories = categorie.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.NameCategorie
            }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Book model)
        {

            if (ModelState.IsValid)
            {
                await _service.Add(model);
                //return View();
                return RedirectToAction("Index","Home");
            }
            // Inițializează ViewBag.Authors pentru a fi disponibil în view
            List<Author> authors = _service.GetAllAuthors();
            ViewBag.Authors = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AuthorBio
            }).ToList();

            List<Categorie> categorie = _service.GetCategories();
            ViewBag.Categories = categorie.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.NameCategorie
            }).ToList();
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
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult AddCategorie() => View();
        [HttpPost]
        public async Task<IActionResult> AddCategorie(Categorie model)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCat(model);
                return RedirectToAction("CIndex","Categorie");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetById(id);
            List<Author> authors = _service.GetAllAuthors();
            ViewBag.Authors = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.AuthorBio
            }).ToList();

            List<Categorie> categorie = _service.GetCategories();
            ViewBag.Categories = categorie.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.NameCategorie
            }).ToList();

            var response = new Book()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                URL = productDetails.URL,
                Descriptions = productDetails.Descriptions,
                BookCategorie = productDetails.BookCategorie,
                Price = productDetails.Price,
            };
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book product)
        {
            //if (ModelState.IsValid)
            //{
                await _service.Update(product);
                return RedirectToAction("Index","Home");
            //}
            //return View(product);
        }


    }
}
