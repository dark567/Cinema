using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(/*int Id*/)
        {
            var myLogin = new LogIn();
            myLogin.Login = "Dark";
            myLogin.Pass = "321";
            //myLogin.Pass = Id.ToString();
            return View("~/Views/Home/LogIn.cshtml", myLogin);
        }
    }
}