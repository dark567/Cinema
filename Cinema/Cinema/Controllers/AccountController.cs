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

        public ActionResult Login(/*int Id*/)
        {
            var myLogin = new LogIn();
            return View("~/Views/Account/LogIn.cshtml", myLogin);
        }

    }
}