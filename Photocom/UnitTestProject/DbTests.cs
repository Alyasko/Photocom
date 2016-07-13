using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Photocom.DataLayer;
using Photocom.DataLayer.Entries;

namespace UnitTestProject
{
    [TestClass]
    public class DbTests
    {
        //[TestMethod]
        public void TestDbContextAdding()
        {

            PhotocomContext context = new PhotocomContext();

            List<UserEntry> users = new List<UserEntry>()
            {
                new UserEntry()
                {
                    AboutUser = "Nice man",
                    Email = "someone@example.com",
                    Login = "man",
                    FirstName = "Alex",
                    LastName = "Fluo",
                    Password = "123",
                    SignUpDate = DateTime.Now
                },
                new UserEntry()
                {
                    AboutUser = "My girl",
                    Email = "someone@example.com",
                    Login = "ilona",
                    FirstName = "Ilona",
                    LastName = "Zelinko",
                    Password = "Ilonochka",
                    SignUpDate = DateTime.Now
                }
            };

            List<CommentEntry> comments = new List<CommentEntry>()
            {
                new CommentEntry() {Author = null, DateAdded = DateTime.Now, Text = "Hey!" },
                new CommentEntry() {Author = null, DateAdded = DateTime.Now, Text = "How are you?" }
            };

            //context.Users.AddRange(users);
            //context.SaveChanges();
        }

        [TestMethod]
        public void TestUnitOfWork()
        {
            UnitOfWork unitOfWork = new UnitOfWork();

            var list = unitOfWork.UserRepository.GetAll().ToList();

            Assert.IsNotNull(list);
        }
    }
}
