using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photocom.Contracts;
using Photocom.DataLayer;

namespace Photocom.Presentation.Controllers
{
    public class BaseController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }

        protected BaseController()
        {
            UnitOfWork = new UnitOfWork();
        }

        protected BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected Guid GetSessionId()
        {
            Guid sessionId = Guid.Empty;

            if (Session["id"] != null)
            {
                sessionId = (Guid)Session["id"];
            }
            else
            {
                sessionId = Guid.NewGuid();
                Session["id"] = sessionId;
            }

            return sessionId;
        }
    }
}