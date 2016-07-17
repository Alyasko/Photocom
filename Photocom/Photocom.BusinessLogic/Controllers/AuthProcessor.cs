﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Photocom.Contracts;
using Photocom.Models.Entities;
using Photocom.Models.Entities.Database;
using Photocom.Models.Enums;
using Photocom.Models.Enums.Validation;

namespace Photocom.BusinessLogic.Controllers
{
    public class AuthProcessor
    {
        private Session _loggedInSession;
        private ValidationProcessor _validationController;

        public AuthProcessor(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;

            _loggedInSession = null;
            _validationController = new ValidationProcessor();
        }

        /// <summary>
        /// Shoud be called in every action.
        /// </summary>
        /// <param name="sessionId"></param>
        public virtual bool TryInitCurrentSession(Guid sessionId)
        {
            _loggedInSession = UnitOfWork.SessionRepository.GetSessionBySessionId(sessionId.ToString());
            return _loggedInSession != null;
        }

        public virtual SignUpResult SignUp(UserSignUpInfo signUpInfo)
        {
            SignUpResult result = SignUpResult.Successful;

            if (UnitOfWork.UserRepository.GetUserByLogin(signUpInfo.Login) == null)
            {
                // User with such login does NOT exist.
                result = _validationController.CheckSignUpInfo(signUpInfo);

                if (result == SignUpResult.Successful)
                {
                    User newUser = new User()
                    {
                        AboutUser = signUpInfo.AboutUser,
                        Password = signUpInfo.Password,
                        Login = signUpInfo.Login,
                        SignUpDate = DateTime.Now,
                        FirstName = signUpInfo.FirstName,
                        LastName = signUpInfo.LastName,
                        Email = signUpInfo.Email,
                        GUID = Guid.NewGuid()
                    };

                    UnitOfWork.UserRepository.Insert(newUser);
                    UnitOfWork.SaveChanges();
                }
            }
            else
            {
                // User with such login does exist.
                result |= SignUpResult.LoginAlreadyTaken;
            }

            return result;
        }

        public virtual LoginResult Login(UserLoginInfo loginInfo)
        {
            LoginResult result = LoginResult.Successful;

            User userToLogin = UnitOfWork.UserRepository.GetUserByLogin(loginInfo.Login);

            if (userToLogin == null)
            {
                // User does not exist.
                result |= LoginResult.UserNotExists;
            }
            else
            {
                // User exists.

                Session existingSession = UnitOfWork.SessionRepository.GetSessionBySessionId(loginInfo.SessionId);

                if (existingSession == null)
                {
                    // User is not logged in.

                    if (loginInfo.Password.Equals(userToLogin.Password))
                    {
                        // Password okay.
                        Session session = new Session();
                        session.User = userToLogin;
                        session.LoggedInDate = DateTime.Now;
                        session.SessionId = loginInfo.SessionId;
                        session.Host = loginInfo.Host;
                        session.UserAgent = loginInfo.UserAgent;

                        _loggedInSession = session;

                        UnitOfWork.SessionRepository.Insert(session);
                        UnitOfWork.SaveChanges();

                        result |= LoginResult.Successful;
                    }
                    else
                    {
                        // Password is incorrect.
                        result |= LoginResult.IncorrectPassword;
                    }
                }
                else
                {
                    // User has been logged in.
                    result |= LoginResult.AlreadyLoggedIn;

                    _loggedInSession = existingSession;
                }
            }


            return result;
        }

        public virtual LogoutResult Logout()
        {
            LogoutResult result = LogoutResult.Successful;

            if (_loggedInSession == null)
            {
                // No session stored.
                result |= LogoutResult.NoSession;
            }
            else
            {
                UnitOfWork.SessionRepository.Delete(_loggedInSession);
                UnitOfWork.SaveChanges();

                _loggedInSession = null;
            }

            return result;
        }

        public virtual Session GetCurrentSession()
        {
            return _loggedInSession;
        }

        public virtual User GetCurrentUser()
        {
            return _loggedInSession.User;
        }

        public IUnitOfWork UnitOfWork { get; set; }
    }
}
