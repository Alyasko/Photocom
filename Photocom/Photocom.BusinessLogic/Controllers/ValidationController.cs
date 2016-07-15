using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Photocom.Models.Entities;
using Photocom.Models.Enums.Validation;

namespace Photocom.BusinessLogic.Controllers
{
    public class ValidationController
    {
        public const int LoginMinLength = 3;
        public const int AboutUserMinLength = 30;
        public const int PasswordMinLength = 5;

        public SignUpResult CheckSignUpInfo(UserSignUpInfo signUpInfo)
        {
            SignUpResult result = SignUpResult.Successful;

            if (signUpInfo.Login.Length <= LoginMinLength)
            {
                result |= SignUpResult.LoginTooShort;
            }

            if (signUpInfo.AboutUser.Length <= AboutUserMinLength)
            {
                result |= SignUpResult.AboutUserTooShort;
            }

            if (signUpInfo.Password.Length <= PasswordMinLength)
            {
                result |= SignUpResult.PasswordTooShort;
            }

            if (!signUpInfo.Password.Equals(signUpInfo.ConfirmationPassword))
            {
                result |= SignUpResult.PasswordsMissmatch;
            }

            if (string.IsNullOrWhiteSpace(signUpInfo.FirstName))
            {
                result |= SignUpResult.FirstNameIsEmpty;
            }

            if (string.IsNullOrWhiteSpace(signUpInfo.LastName))
            {
                result |= SignUpResult.LastNameIsEmpty;
            }

            string emailPattern =
                @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            if (!Regex.IsMatch(signUpInfo.Email, emailPattern))
            {
                result |= SignUpResult.EmailNotCorrect;
            }

            return result;
        }
    }
}
