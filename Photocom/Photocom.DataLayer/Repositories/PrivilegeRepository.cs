using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Contracts.Repositories;
using Photocom.DataLayer.Repositories;
using Photocom.Models.Entities;

namespace Photocom.DataLayer.Repositories
{
    public class PrivilegeRepository : AbstractRepository<Privilege>, IPrivilegeRepository
    {
        public PrivilegeRepository(DbContext context) : base(context)
        {
        }
    }
}
