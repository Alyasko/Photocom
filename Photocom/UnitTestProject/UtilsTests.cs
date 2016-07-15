using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Photocom.BusinessLogic.Utils;
using Photocom.Models.Entities.Database;

namespace UnitTestProject
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void PhotoMembersTest()
        {
            // Arrange
            DateTime time = DateTime.Now;
            Photo photoEntry = new Photo()
            {
                Description = "Hello",
                Likes = new List<User>(),
                Comments = new List<Comment>(),
                HashTags = new List<string>(),
                PublicationDate = time,
            };
            Photo photo = null;

            // Act

            photo = ReflectionHelper.ConvertClassInstances<Photo>(ReflectionHelper.GetFullTypeName(typeof(Photo)), photoEntry);

            // Assert
            Assert.AreEqual(photo.Comments, photoEntry.Comments);
            Assert.AreEqual(photo.Description, photoEntry.Description);
            Assert.AreEqual(photo.HashTags, photoEntry.HashTags);
            Assert.AreEqual(photo.Likes.Count, photoEntry.Likes.Count());
            Assert.AreEqual(photo.PublicationDate, photoEntry.PublicationDate);
        }

        [TestMethod]
        public void TestConvertToModelMethodOfEntry()
        {
            User userEntry = new User()
            {
                AboutUser = "I am a man",
                SignUpDate = DateTime.Now,
                Login = "Hey",
                FirstName = "Sasha",
                LastName = "Yasko",
                Email = "null",
                Password = "123",
                GUID = Guid.NewGuid()
            };

            //User model = userEntry.ConvertToModel<User>();

//            Assert.AreEqual(userEntry.AboutUser, model.AboutUser);
        }

        [TestMethod]
        public void PhotoAssemblyNameTest()
        {
            string targetType = "Photocom.Models.Entities.Photo, Photocom.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            string actualType = "";

            actualType = ReflectionHelper.GetFullTypeName(typeof(Photo));

            Assert.IsTrue(targetType.Equals(actualType));
        }
    }
}
