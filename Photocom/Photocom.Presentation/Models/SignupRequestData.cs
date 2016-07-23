using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photocom.Presentation.Models
{
    public class SignupRequestData
    {
        public string AboutUser { get; set; }

        public string ConfirmationPassword { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}