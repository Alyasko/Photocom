using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photocom.Models.Entities.Database
{
    public class Like : BaseEntity
    {
        public User User { get; set; }
        public Photo Photo { get; set; }
    }
}
