using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photocom.BusinessLogic.Controllers;
using Photocom.Contracts;
using Photocom.DataLayer;
using Photocom.Presentation.ViewModels;

namespace Photocom.Presentation.Controllers
{
    public class PartialController : BaseController
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public PartialController()
        {
            UnitOfWork = new UnitOfWork();
        }

        public PartialController(IUnitOfWork unitOfWork)
        {
            
        }

        public ActionResult Login()
        {
            return PartialView("LoginForm");
        }

        public ActionResult Signup()
        {
            return PartialView("SignupForm");
        }

        [HttpGet]
        public ActionResult GetLoggedInUser()
        {
            AuthProcessor authProcessor = new AuthProcessor(UnitOfWork);
            LoggedInUserViewModel viewModel = new LoggedInUserViewModel();
           
            Guid sessionId = GetSessionId();
            bool isLoggedIn = authProcessor.TryInitCurrentSession(sessionId);

            if (isLoggedIn)
            {
                viewModel.IsLoggedIn = isLoggedIn;
                viewModel.UserName = authProcessor.GetCurrentUser().FirstName;
                viewModel.PhotoPath = "";
            }

            return PartialView("UserToolbar", viewModel);
        }
    }
}