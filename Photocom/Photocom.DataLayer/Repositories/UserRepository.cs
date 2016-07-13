using Photocom.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Contracts;
using Photocom.Contracts.Repositories;
using Photocom.DataLayer.Repositories;

namespace Photocom.DataLayer.Repositories
{
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User GetUserByLogin(string login)
        {
            return DbContext.Set<User>().First(x => x.Login.Equals(login));
        }

        public User GetUserByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public User GetUserBySignUpDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public User GetUserBySignUpDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public User GetUserByPassword(string password)
        {
            throw new NotImplementedException();
        }

    }
}
