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

        [HttpPost]
        public async Task<IActionResult> LogIn(ULoginData model)
        {
                var user = await _service.Authenticate(model.Credential, model.Password);
                if (user != null)
                {
                    // Autentificare reușită
                    // Setarea unui cookie pentru a reține autentificarea
                    // Creează un token de autentificare unic pentru utilizator
                    string authToken = Guid.NewGuid().ToString();

                    // Creați opțiunile pentru cookie
                    var cookieOptions = new CookieOptions
                    {
                        // Setează data de expirare a cookie-ului (ex: 30 de zile)
                        Expires = DateTime.Now.AddDays(30),
                        // Asigură că cookie-ul este accesibil doar prin HTTP și nu prin JavaScript
                        HttpOnly = true
                    };

                    // Setează cookie-ul cu tokenul de autentificare
                    Response.Cookies.Append("AuthCookie", authToken, cookieOptions);

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
