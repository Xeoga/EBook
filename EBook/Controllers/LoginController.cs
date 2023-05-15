using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EBook.Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EBook.BussinesLogic.Services;

namespace EBook.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _service;
        public LoginController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SingUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SingUp(ULoginData model)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(model);
                return RedirectToAction(nameof(LogIn));
            }
            return View();
        }


    }
}
