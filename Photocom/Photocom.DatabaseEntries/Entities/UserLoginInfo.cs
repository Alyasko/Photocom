using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Photocom.Models.Entities
{
    public class UserLoginInfo
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string SessionId { get; set; }

        public string UserAgent { get; set; }

        public string Host { get; set; }
    }
}
