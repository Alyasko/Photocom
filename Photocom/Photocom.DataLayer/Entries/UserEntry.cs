using System;
using System.ComponentModel.DataAnnotations;
using Photocom.Models.Entities;

namespace Photocom.DataLayer.Entries
{
    public class UserEntry //: BaseEntry<User>
    {
        [Key]
        public int Id { get; set; }
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual string AboutUser { get; set; }

        public virtual Guid GUID { get; set; }

        public virtual string Login { get; set; }

        public virtual DateTime SignUpDate { get; set; }
    }
}
