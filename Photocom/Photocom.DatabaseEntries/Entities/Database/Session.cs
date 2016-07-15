using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Models.Entities.Database;

namespace Photocom.Models.Entities.Database
{
    public class Session : BaseEntity
    {
        public string SessionId { get; set; }

        public DateTime LoggedInDate { get; set; }

        public User User { get; set; }

        public string UserAgent { get; set; }

        public string Host { get; set; }
    }
}

