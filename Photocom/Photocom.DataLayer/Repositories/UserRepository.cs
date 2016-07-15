using Photocom.Models.Entities.Database;
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
            return DbContext.Set<User>().FirstOrDefault(x => x.Login.Equals(login));
        }

        public User GetUserByGuid(Guid guid)
        {
            return DbContext.Set<User>().FirstOrDefault(x => x.GUID == guid);
        }

        public User GetUserBySignUpDate(DateTime date)
        {
            return DbContext.Set<User>().FirstOrDefault(x => x.SignUpDate == date);
        }

        public User GetUserBySignUpDate(DateTime startDate, DateTime endDate)
        {
            return DbContext.Set<User>().FirstOrDefault(x => x.SignUpDate >= startDate && x.SignUpDate <= endDate);
        }

        public User GetUserByPassword(string password)
        {
            return DbContext.Set<User>().FirstOrDefault(x => x.Password.Equals(password));
        }

    }
}
