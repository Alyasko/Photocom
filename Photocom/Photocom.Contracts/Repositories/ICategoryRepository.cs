using Photocom.Models.Entities.Database;

namespace Photocom.Contracts.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByPhoto(Photo photo);
    }
}
