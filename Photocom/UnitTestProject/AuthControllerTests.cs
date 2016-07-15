using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Photocom.BusinessLogic.Controllers;
using Photocom.Contracts;
using Photocom.DataLayer;
using Photocom.Models.Entities;
using Photocom.Models.Entities.Database;
using Photocom.Models.Enums;
using Photocom.Models.Enums.Validation;

namespace UnitTestProject
{
    [TestClass]
    public class AuthControllerTests
    {
        [TestMethod]
        public void TestLoginWithIncorrectPassword()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            AuthController authController = new AuthController(unitOfWork);

            UserLoginInfo userLoginInfo = new UserLoginInfo()
            {
                Login = "alyasko",
                Password = "123",
                SessionId = "xyzabcd"
            };

            LoginResult result = authController.Login(userLoginInfo);

            Assert.AreNotEqual(result, LoginResult.UserNotExists);
        }

        [TestMethod]
        public void TestLoginWithCorrectPassword()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            AuthController authController = new AuthController(unitOfWork);

            UserLoginInfo userLoginInfo = new UserLoginInfo()
            {
                Login = "alyasko",
                Password = "alyasko123",
                SessionId = "xyzabcd"
            };

            LoginResult result = authController.Login(userLoginInfo);

            //Assert.AreNotEqual(result, LoginResult.UserNotExists);
        }

        [TestMethod]
        public void TestLogout()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            AuthController authController = new AuthController(unitOfWork);

            bool sesionInit = authController.TryInitCurrentSession("xyzabcd");
            Session session = authController.GetCurrentSession();

            authController.Logout();

            Session session2 = authController.GetCurrentSession();
        }

        [TestMethod]
        public void TestLoginWithIncorrectLogin()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            AuthController authController = new AuthController(unitOfWork);

            UserLoginInfo userLoginInfo = new UserLoginInfo()
            {
                Login = "alysko",
                Password = "alyasko123",
                SessionId = "xyzabcd"
            };

            LoginResult result = authController.Login(userLoginInfo);

            //Assert.AreNotEqual(result, LoginResult.UserNotExists);
        }

        [TestMethod]
        public void TestSignUp()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            AuthController authController = new AuthController(unitOfWork);

            UserSignUpInfo userSignUpInfo = new UserSignUpInfo()
            {
                AboutUser = "I am a student of CSN from KHAI :)",
                ConfirmationPassword = "alyasko123",
                Password = "alyasko123",
                Email = "someone@example.com",
                FirstName = "Alexander",
                LastName = "Yasko",
                Login = "alyasko"
            };

            SignUpResult result = authController.SignUp(userSignUpInfo);

            Assert.AreEqual(SignUpResult.Successful, result);
        }
    }
}
