using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photocom.Models.Enums.Validation
{
    [Flags]
    public enum SignUpResult
    {
        Successful = 0,
        LoginTooShort = 2,
        AboutUserTooShort = 4,
        PasswordTooShort = 8,
        PasswordsMissmatch = 16,
        FirstNameIsEmpty = 32,
        LastNameIsEmpty = 64,
        EmailNotCorrect = 128,
        LoginAlreadyTaken = 256
    }
}
