using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Models.Entities;

namespace Photocom.Contracts
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
