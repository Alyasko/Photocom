using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photocom.Models.Entities
{
    public class UserSignUpInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
        public string Email { get; set; }
        public string AboutUser { get; set; }
    }
}
