using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Photocom.Presentation.Controllers
{
    public class PartialController : Controller
    {
        public ActionResult Login()
        {
            return PartialView("LoginForm");
        }

        public ActionResult Signup()
        {
            return PartialView("SignupForm");
        }
    }
}