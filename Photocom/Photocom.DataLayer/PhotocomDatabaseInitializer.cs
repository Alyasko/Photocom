using System;
using System.Collections.Generic;
using System.Data.Entity;
using Photocom.DataLayer.Entries;

namespace Photocom.DataLayer
{
    public class PhotocomDatabaseInitializer// : DropCreateDatabaseIfModelChanges<PhotocomContext>
    {
        //public override void InitializeDatabase(PhotocomContext context)
        //{
        //    base.InitializeDatabase(context);

        //    List<UserEntry> users = new List<UserEntry>()
        //    {
        //        new UserEntry()
        //        {
        //            AboutUser = "Nice man",
        //            Email = "someone@example.com",
        //            Login = "man",
        //            FirstName = "Alex",
        //            LastName = "Fluo",
        //            Password = "123",
        //            SignUpDate = DateTime.Now
        //        },
        //        new UserEntry()
        //        {
        //            AboutUser = "My girl",
        //            Email = "someone@example.com",
        //            Login = "ilona",
        //            FirstName = "Ilona",
        //            LastName = "Zelinko",
        //            Password = "Ilonochka",
        //            SignUpDate = DateTime.Now
        //        }
        //    };

        //    List<CommentEntry> comments = new List<CommentEntry>()
        //    {
        //        new CommentEntry() {Author = null, DateAdded = DateTime.Now, Text = "Hey!" },
        //        new CommentEntry() {Author = null, DateAdded = DateTime.Now, Text = "How are you?" }
        //    };

        //    context.Comments.AddRange(comments);
        //    context.SaveChanges();
        //}
    }
}
