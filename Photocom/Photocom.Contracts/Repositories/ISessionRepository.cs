using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Models.Entities.Database;

namespace Photocom.Contracts.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        User GetUserBySession(string sessionId);

        Session GetSessionBySessionId(string sessionId);

        bool SessionExists(string sessionId);

        IEnumerable<Session> GetSessionsByUser(User user);
    }
}
