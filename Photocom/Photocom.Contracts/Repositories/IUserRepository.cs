using System;
using Photocom.Models.Entities.Database;

namespace Photocom.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByLogin(string login);

        User GetUserByGuid(Guid guid);

        User GetUserBySignUpDate(DateTime date);

        User GetUserBySignUpDate(DateTime startDate, DateTime endDate);

        User GetUserByPassword(string password);
    }
}
