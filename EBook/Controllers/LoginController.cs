using EBook.BussinesLogic;
using EBook.Domain.Entities.User;
using eUseControl.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSession();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Credential = login.Credential,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };

                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    Session["Username"] = login.Credential;
                    HttpCookie cookie = _session.GenCookie(login.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }

            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


    }
}
}