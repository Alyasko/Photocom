using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Contracts.Repositories;
using Photocom.Models.Entities.Database;

namespace Photocom.DataLayer.Repositories
{
    public class SessionRepository : AbstractRepository<Session>, ISessionRepository
    {
        public SessionRepository(DbContext context) : base(context)
        {
        }

        public User GetUserBySession(string sessionId)
        {
            return DbContext.Set<Session>().FirstOrDefault(x => x.SessionId.Equals(sessionId))?.User;
        }

        public Session GetSessionBySessionId(string sessionId)
        {
            return DbContext.Set<Session>().Include(x => x.User).FirstOrDefault(x => x.SessionId.Equals(sessionId));
        }

        public bool SessionExists(string sessionId)
        {
            return DbContext.Set<Session>().FirstOrDefault(x => x.SessionId.Equals(sessionId)) == null;
        }

        public IEnumerable<Session> GetSessionsByUser(User user)
        {
            return DbContext.Set<Session>().Where(x => x.User == user).ToList();
        }
    }
}
