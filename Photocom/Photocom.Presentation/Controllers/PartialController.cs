using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photocom.BusinessLogic.Controllers;
using Photocom.Contracts;
using Photocom.DataLayer;
using Photocom.Models.Entities.Database;
using Photocom.Presentation.ViewModels;

namespace Photocom.Presentation.Controllers
{
    public class PartialController : BaseController
    {

        public ActionResult Login()
        {
            return PartialView("LoginForm");
        }

        public ActionResult Signup()
        {
            return PartialView("SignupForm");
        }

        public ActionResult LoadPhoto(int id)
        {
            ActionResult result = HttpNotFound("There is no photo with specified id.");
            PhotoForViewViewModel viewModel = new PhotoForViewViewModel();
            Photo photo = UnitOfWork.PhotoRepository.GetPhotoById(id);

            if (photo != null)
            {
                viewModel.Photo = photo;
                result = PartialView("PhotoForView", viewModel);
            }

            return result;
        }

        [HttpGet]
        public ActionResult GetUserToolbar()
        {
            AuthProcessor authProcessor = new AuthProcessor(UnitOfWork);
            LoggedInUserViewModel viewModel = new LoggedInUserViewModel();
           
            Guid sessionId = GetSessionId();
            bool isLoggedIn = authProcessor.TryInitCurrentSession(sessionId);

            if (isLoggedIn)
            {
                User user = authProcessor.GetCurrentUser();

                viewModel.IsLoggedIn = isLoggedIn;
                viewModel.UserName = user.FirstName;
                viewModel.Login = user.Login;
                viewModel.PhotoPath = "";
            }

            return PartialView("UserToolbar", viewModel);
        }
    }
}