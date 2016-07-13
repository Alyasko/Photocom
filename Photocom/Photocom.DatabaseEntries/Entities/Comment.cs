using System;

namespace Photocom.Models.Entities
{
    public class Comment
    {
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public User Author { get; set; }
    }
}