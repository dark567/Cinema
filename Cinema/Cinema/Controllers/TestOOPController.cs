using Cinema.Models;
using Cinema.Models.TestOOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class TestOOPController : Controller
    {
        public ActionResult TestInheritance()
        {
            var testVariable = new TestClass();
            TestIntefaceParam(testVariable);
            return null;
        }


        private string TestIntefaceParam(TestInterface implemantation)
        {
            var test = (TestClass)implemantation;
            return null;
        }

    }
}