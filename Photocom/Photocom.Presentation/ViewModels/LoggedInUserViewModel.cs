using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photocom.Presentation.ViewModels
{
    public class LoggedInUserViewModel
    {
        public string UserName { get; set; }
        public string PhotoPath { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}