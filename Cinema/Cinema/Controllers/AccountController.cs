using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login(/*int Id*/)
        {
            var myLogin = new LogIn();
            return View("~/Views/Account/LogIn.cshtml", myLogin);
        }

        [HttpPost]
        public ActionResult Login(LogIn loginResult)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Account/LogIn.cshtml", loginResult);
            }
            return View("~/Views/Account/LoginResult.cshtml", loginResult);
        }

    }
}