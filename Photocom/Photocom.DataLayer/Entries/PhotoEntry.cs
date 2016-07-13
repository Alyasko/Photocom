using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Photocom.Models.Entities;

namespace Photocom.DataLayer.Entries
{
    public class PhotoEntry : BaseEntry<Photo>
    {
        public virtual IList<CommentEntry> Comments { get; set; }

        public virtual IList<string> HashTags { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<UserEntry> Likes { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
