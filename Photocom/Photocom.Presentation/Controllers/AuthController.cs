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
using Photocom.Presentation.Models;

namespace Photocom.Presentation.Controllers
{
    public class AuthController : BaseController
    {

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

        [HttpPost]
        public ActionResult Signup(SignupRequestData signupData)
        {
            AuthProcessor authProcessor = new AuthProcessor(UnitOfWork);

            UserSignUpInfo signUpInfo = new UserSignUpInfo();
            signUpInfo.AboutUser = signupData.AboutUser;
            signUpInfo.ConfirmationPassword = signupData.ConfirmationPassword;
            signUpInfo.Email = signupData.Email;
            signUpInfo.FirstName = signupData.FirstName;
            signUpInfo.LastName = signupData.LastName;
            signUpInfo.Login = signupData.Login;
            signUpInfo.Password = signupData.Password;

            SignUpResult signUpResult = authProcessor.SignUp(signUpInfo);


            return Json(new { Result = signUpResult.ToString() });
        }
    }
}