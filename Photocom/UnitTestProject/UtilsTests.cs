using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Photocom.BusinessLogic.Utils;
using Photocom.DataLayer.Entries;
using Photocom.Models.Entities;

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
            PhotoEntry photoEntry = new PhotoEntry()
            {
                Description = "Hello",
                Likes = new List<UserEntry>(),
                Comments = new List<CommentEntry>(),
                HashTags = new List<string>(),
                PublicationDate = time,
                Id = 101
            };
            Photo photo = null;

            // Act

            photo = ReflectionHelper.ConvertClassInstances<Photo>(ReflectionHelper.GetFullTypeName(typeof(PhotoEntry)), photoEntry);

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
            UserEntry userEntry = new UserEntry()
            {
                AboutUser = "I am a man",
                SignUpDate = DateTime.Now,
                Login = "Hey",
                FirstName = "Sasha",
                LastName = "Yasko",
                Email = "null",
                Password = "123",
                Id = 100,
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
