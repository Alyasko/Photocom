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
    public class LikeRepository : AbstractRepository<Like>, ILikeRepository
    {
        public LikeRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Like> GetLikesByPhotoId(int id)
        {
            return DbContext.Set<Like>().Where(x => x.Photo.Id == id).ToList();
        }

        public bool RemoveLikeByUserAndPhoto(Photo photo, User user)
        {
            bool result = false;
            Like likeToRemove =
                DbContext.Set<Like>().FirstOrDefault(x => x.User.Login.Equals(user.Login) && x.Photo.Id == photo.Id);

            if (likeToRemove != null)
            {
                DbContext.Set<Like>().Remove(likeToRemove);
                result = true;
            }

            return result;
        }
    }
}
