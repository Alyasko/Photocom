using System;

namespace Photocom.Models.Enums.Validation
{
    [Flags]
    public enum LoginResult
    {
        Successful = 0,
        AlreadyLoggedIn = 2,
        UserNotExists = 4,
        IncorrectPassword = 8
    }
}
