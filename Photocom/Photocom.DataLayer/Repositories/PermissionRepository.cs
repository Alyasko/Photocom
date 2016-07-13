using System.Data.Entity;
using Photocom.Contracts.Repositories;
using Photocom.Models.Entities;

namespace Photocom.DataLayer.Repositories
{
    public class PermissionRepository : AbstractRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DbContext context) : base(context)
        {
        }
    }
}
