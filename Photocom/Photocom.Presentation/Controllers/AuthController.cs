using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photocom.DataLayer;
using Photocom.Models.Entities;
using Photocom.Models.Enums.Validation;
using BL = Photocom.BusinessLogic.Controllers;

namespace Photocom.Presentation.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public ActionResult Login(LoginRequestData loginData)
        {
            BL.AuthController authController = new BL.AuthController(new UnitOfWork());

            Guid sessionId = Guid.Empty;
            if (Session["id"] != null)
            {
                sessionId = (Guid) Session["id"];
            }
            else
            {
                sessionId = Guid.NewGuid();
                Session["id"] = sessionId;
            }

            UserLoginInfo loginInfo = new UserLoginInfo();
            loginInfo.Login = loginData.Login;
            loginInfo.Password = loginData.Password;
            loginInfo.SessionId = sessionId.ToString();
            loginInfo.Host = Request.UserHostAddress;
            loginInfo.UserAgent = Request.UserAgent;

            LoginResult loginResult = authController.Login(loginInfo);

            return Json(new { Message = $"LoginResult: {loginResult.ToString()}" });
        }

        [HttpPost]
        public ActionResult Logout()
        {
            return Content("Login");
        }
    }
}