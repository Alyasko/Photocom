﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Photocom.Presentation.Controllers
{
    public class BaseController : Controller
    {
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