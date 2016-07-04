using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photocom.BLL.Entities
{
    public class Photo
    {
        public Photo()
        {
            
        }

        public IEnumerable<Comment> Comments { get; set; } 
    }
}
