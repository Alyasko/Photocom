using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photocom.BusinessLogic.Controllers;
using Photocom.Contracts;
using Photocom.DataLayer;
using Photocom.Models.Entities;
using Photocom.Models.Enums.Validation;

namespace Photocom.Presentation.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController()
        {
            UnitOfWork = new UnitOfWork();
        }

        public AuthController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; set; }

        [HttpPost]
        public ActionResult Login(LoginRequestData loginData)
        {
            AuthProcessor authProcessor = new AuthProcessor(UnitOfWork);

            Guid sessionId = GetSessionId();

            UserLoginInfo loginInfo = new UserLoginInfo();
            loginInfo.Login = loginData.Login;
            loginInfo.Password = loginData.Password;
            loginInfo.SessionId = sessionId.ToString();
            loginInfo.Host = Request.UserHostAddress;
            loginInfo.UserAgent = Request.UserAgent;

            LoginResult loginResult = authProcessor.Login(loginInfo);

            return Json(new { Result = loginResult.ToString() });
        }

        [HttpGet]
        public ActionResult Logout()
        {
            AuthProcessor authProcessor = new AuthProcessor(UnitOfWork);
            ActionResult result = new EmptyResult();
            Guid sessionId = GetSessionId();
            authProcessor.TryInitCurrentSession(sessionId);

            LogoutResult logoutResult = authProcessor.Logout();

            if (logoutResult == LogoutResult.Successful)
            {
                result = RedirectToAction("Index", "Home");
            }

            return result;
        }
    }
}