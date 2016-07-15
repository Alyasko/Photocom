using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Contracts;
using Photocom.Contracts.Repositories;
using Photocom.DataLayer.Repositories;
using Photocom.Models.Entities.Database;

namespace Photocom.DataLayer.Repositories
{
    public class PhotoRepository : AbstractRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Photo> GetLastPhotos(int skip, int count)
        {
            return DbContext.Set<Photo>().OrderByDescending((x) => x.PublicationDate).Skip(skip).Take(count).ToArray();
        }

        public IEnumerable<Photo> GetLastPhotos(Category category, int skip, int count)
        {
            return DbContext.Set<Photo>().Where(x => x.Category == category).OrderByDescending(x => x.PublicationDate)
                .Skip(skip).Take(count).ToArray();
        }

        public IEnumerable<Photo> GetPhotosByUser(User user)
        {
            return DbContext.Set<Photo>().Where(x => x.Author == user).ToArray();
        }

        public IEnumerable<Photo> GetPhotosByHashTag(string hashTag)
        {
            return DbContext.Set<Photo>().Where(x => x.HashTags.Contains(hashTag)).ToArray();
        }

        public IEnumerable<Photo> GetPhotosByDescription(string description)
        {
            return DbContext.Set<Photo>().Where(x => x.Description.Contains(description)).ToArray();
        }

        public IEnumerable<Photo> GetPhotosByPublicationDate(DateTime publicationDate)
        {
            return DbContext.Set<Photo>().Where(x => x.PublicationDate == publicationDate).ToArray();
        }

        public IEnumerable<Photo> GetPhotosByPublicationDate(DateTime startDate, DateTime endDate)
        {
            return DbContext.Set<Photo>().Where(x => x.PublicationDate >= startDate && x.PublicationDate <= endDate).ToArray();
        }
    }
}
