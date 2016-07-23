using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photocom.Presentation.ViewModels;

namespace Photocom.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {

            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Photos = UnitOfWork.PhotoRepository.GetLastPhotos(0, 10);

            return View(viewModel);
        }

        public ActionResult Test()
        {
            object session = Session["hello"];

            return new EmptyResult();
        }
    }
}