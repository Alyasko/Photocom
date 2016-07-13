using System;
using System.ComponentModel.DataAnnotations;
using Photocom.Models.Entities;

namespace Photocom.DataLayer.Entries
{
    public class CommentEntry : BaseEntry<Comment>
    {
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public UserEntry Author { get; set; }
    }
}
