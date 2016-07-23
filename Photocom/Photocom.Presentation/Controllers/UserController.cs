using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photocom.BusinessLogic.Controllers;
using Photocom.Models.Entities.Database;
using Photocom.Presentation.ViewModels;

namespace Photocom.Presentation.Controllers
{
    public class UserController : BaseController
    {
        [HttpPost]
        public ActionResult LoadPhoto(HttpPostedFileBase file, string title, string login, string description, string hashTags)
        {
            ActionResult result = RedirectToAction("ViewProfile", new {Login = login});

            if (file == null)
            {
                result = new HttpNotFoundResult("No file selected for uploading.");
            }

            if (file.ContentLength > 0 && file.ContentLength < 10 * 1024 * 1024)
            {
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                string newPath = Path.Combine(Server.MapPath("~/Photos"), fileName);
                User photoAuthor = UnitOfWork.UserRepository.GetUserByLogin(login);

                if (photoAuthor != null)
                {
                    file.SaveAs(newPath);

                    Photo newPhoto = new Photo();
                    newPhoto.Title = title;
                    newPhoto.Path = fileName;
                    newPhoto.Author = photoAuthor;
                    newPhoto.Category = null;
                    newPhoto.Comments = null;
                    newPhoto.Description = description;
                    newPhoto.HashTags = hashTags.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(x => new HashTag() { Value = x}).ToList();
                    newPhoto.Likes = null;
                    newPhoto.PublicationDate = DateTime.Now;

                    UnitOfWork.PhotoRepository.Insert(newPhoto);
                    UnitOfWork.SaveChanges();
                }
                else
                {
                    result = new HttpNotFoundResult("You are not authorized to load photos.");
                }
            }
            else
            {
                result = Content("Photo size is " + file.ContentLength + " and it is too large.");
            }

            return result;
        }

        // GET: User
        public ActionResult ViewProfile(string login)
        {
            UserViewModel viewModel = new UserViewModel();

            User user = UnitOfWork.UserRepository.GetUserByLogin(login);
            ActionResult result = new HttpNotFoundResult("No user in database with such login");

            AuthProcessor authProcessor = new AuthProcessor(UnitOfWork);
            authProcessor.TryInitCurrentSession(GetSessionId());
            User loggedInUser = authProcessor.GetCurrentUser();

            bool showOtherUserPhotos = false;

            if (user != null)
            {
                // User that is being requested exists.

                viewModel.User = user;
                viewModel.UserPhotos = UnitOfWork.PhotoRepository.GetPhotosByUser(user);

                if (loggedInUser != null)
                {
                    if (loggedInUser.Login.Equals(login))
                    {
                        // Visitor requests his profile page.
                        viewModel.ShowPrivateControls = true;
                    }
                    else
                    {
                        // Visitor requests other profile page.
                        showOtherUserPhotos = true;
                    }
                }
                else
                {
                    // Nobody is logged in. Show photos by user.
                    showOtherUserPhotos = true;
                }

                if (showOtherUserPhotos)
                {
                    // We should just show photos list of target user.
                    // We don't give the possibility to upload photos.
                    viewModel.ShowPrivateControls = false;
                }

                result = View(viewModel);
            }


            return result;
        }

    }
}