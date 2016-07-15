using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Photocom.Contracts;
using Photocom.DataLayer;
using Photocom.Models.Entities.Database;

namespace UnitTestProject
{
    [TestClass]
    public class DbTests
    {
        [TestMethod]
        public void TestDbContextAdding()
        {

            PhotocomContext context = new PhotocomContext();

            List<User> users = new List<User>()
            {
                new User()
                {
                    AboutUser = "Nice man",
                    Email = "someone@example.com",
                    Login = "man",
                    FirstName = "Alex",
                    LastName = "Fluo",
                    Password = "123",
                    SignUpDate = DateTime.Now
                },
                new User()
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

            List<Comment> comments = new List<Comment>()
            {
                new Comment() {Author = null, DateAdded = DateTime.Now, Text = "Hey!" },
                new Comment() {Author = null, DateAdded = DateTime.Now, Text = "How are you?" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        [TestMethod]
        public void TestUnitOfWork()
        {
            UnitOfWork unitOfWork = new UnitOfWork();

            var list = unitOfWork.UserRepository.GetAll().ToList();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void TestAddingViaUnitOfWork()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();

            var users = unitOfWork.UserRepository.GetAll();
        }
    }
}
