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
        [TestMethod]
        public void TestSeedMethod()
        {
            //Database.SetInitializer(new PhotocomDatabaseInitializer());
            //UnitOfWork unitOfWork = new UnitOfWork();

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

            var asd = new List<TestEntity>()
            {
                new TestEntity() { Text = "123"},
                new TestEntity() { Text = "asd"}
            };

            context.Users.AddRange(users);
            context.SaveChanges();


            //var list = unitOfWork.UserRepository.GetAll().ToList();
        }
    }
}
