using System;
using System.Collections.Generic;
using Photocom.Models.Entities.Database;

namespace Photocom.Contracts.Repositories
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        Photo GetPhotoById(int id);

        IEnumerable<Photo> GetLastPhotos(int skip, int count);

        IEnumerable<Photo> GetLastPhotos(Category category, int skip, int count);

        IEnumerable<Photo> GetPhotosByUser(User user);

        IEnumerable<Photo> GetPhotosByHashTag(HashTag hashTag);

        IEnumerable<Photo> GetPhotosByDescription(string description);

        IEnumerable<Photo> GetPhotosByPublicationDate(DateTime publicationDate);

        IEnumerable<Photo> GetPhotosByPublicationDate(DateTime startDate, DateTime endDate);
    }
}
