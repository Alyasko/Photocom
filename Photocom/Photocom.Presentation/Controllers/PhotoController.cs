using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photocom.BusinessLogic.Controllers;
using Photocom.Models.Entities.Database;

namespace Photocom.Presentation.Controllers
{
    public class PhotoController : BaseController
    {
        [HttpPost]
        public ActionResult Like(int id)
        {
            ActionResult result;

            PhotosProcessor photosProcessor = new PhotosProcessor(UnitOfWork);
            AuthProcessor authProcessor = new AuthProcessor(UnitOfWork);

            authProcessor.TryInitCurrentSession(GetSessionId());

            User user = authProcessor.GetCurrentUser();
            Photo likedPhoto = UnitOfWork.PhotoRepository.GetPhotoById(id);

            if (likedPhoto != null)
            {
                if (user != null)
                {
                    int likesCount = photosProcessor.Like(likedPhoto, user);
                    result = Json(new {Result = "Success", LikesCount = likesCount});
                }
                else
                {
                    result = Json(new { Result = "Login" });
                }
            }
            else
            {
                result = Json(new { Result = "Liked photo does not exist."});
            }

            return result;
        }
    }
}