using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EBook.Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EBook.BussinesLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EBook.Domain.Entities.User;
using System.Threading.Tasks;

namespace EBook.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _service;
        public LoginController(IUserService service)
        {
            _service = service;
        }
        public IActionResult Logout()
        {
            // Ștergeți cookie-ul de autentificare
            Response.Cookies.Delete("AuthToken");

            // Alte acțiuni necesare pentru deconectare (de exemplu, ștergerea sesiunii sau alte operațiuni personalizate)

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(ULoginData model)
        {
                var user = await _service.Authenticate(model.Credential, model.Password);
                if (user != null)
                {
                // Autentificare reușită
                // Setarea unui cookie pentru a reține autentificarea
                // Creează un token de autentificare unic pentru utilizator
                var token = _service.GenerateToken(user);


                    // Setează cookie-ul cu tokenul de autentificare
                    Response.Cookies.Append("AuthToken", token, new CookieOptions { HttpOnly = true, Secure = true });

                    // Puteți stoca informații suplimentare despre utilizator în cookie, dacă este necesar
                    // Exemplu: Response.Cookies.Append("UserId", user.Id.ToString(), cookieOptions);


                    return RedirectToAction(nameof(HomeController.Index),"Home");//Daca avem eroare schimbam la Home
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid credentials");
                }
            return View(model);
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
