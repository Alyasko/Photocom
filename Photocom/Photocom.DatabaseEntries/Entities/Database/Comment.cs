using System;
using Photocom.Models.Entities.Database;

namespace Photocom.Models.Entities.Database
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public User Author { get; set; }
    }
}