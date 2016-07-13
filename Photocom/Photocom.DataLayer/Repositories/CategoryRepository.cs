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
    public class CategoryRepository : AbstractRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public Category GetCategoryByPhoto(Photo photo)
        {
            throw new NotImplementedException();
        }
    }
}
