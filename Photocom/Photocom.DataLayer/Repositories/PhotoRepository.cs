using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Contracts;
using Photocom.Contracts.Repositories;
using Photocom.DataLayer.Repositories;
using Photocom.Models.Entities;

namespace Photocom.DataLayer.Repositories
{
    public class PhotoRepository : AbstractRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Photo> GetLastPhotos(int count)
        {
            return DbContext.Set<Photo>().OrderByDescending((x) => x.PublicationDate).Take(count);
        }

        public IEnumerable<Photo> GetLastPhotos(Category category, int skip, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetPhotosByUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetPhotosByHashTag(string hashTag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetPhotosByDescription(string description)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetPhotosByPublicationDate(DateTime publicationDate)
        {
            throw new NotImplementedException();
        }

    }
}
