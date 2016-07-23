using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Photocom.Models.Entities.Database;

namespace Photocom.Presentation.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }

        public string AvatarPath { get; set; }

        public IEnumerable<Photo> UserPhotos { get; set; }

        public bool ShowPrivateControls { get; set; }
    }
}