using Photocom.Models.Entities;

namespace Photocom.Contracts.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByPhoto(Photo photo);
    }
}
