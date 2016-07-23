using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Models.Entities.Database;

namespace Photocom.Contracts.Repositories
{
    public interface ILikeRepository : IRepository<Like>
    {
        IEnumerable<Like> GetLikesByPhotoId(int id);

        bool RemoveLikeByUserAndPhoto(Photo photo, User user);
    }
}
