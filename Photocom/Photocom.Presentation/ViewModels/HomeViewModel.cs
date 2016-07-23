using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Photocom.Models.Entities.Database;

namespace Photocom.Presentation.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Photo> Photos { get; set; }
    }
}