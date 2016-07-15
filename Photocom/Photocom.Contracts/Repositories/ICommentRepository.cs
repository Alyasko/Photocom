using System;
using System.Collections.Generic;
using Photocom.Models.Entities.Database;

namespace Photocom.Contracts.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetCommentsByUser(User user);

        IEnumerable<Comment> GetCommentsByDate(DateTime date);

        IEnumerable<Comment> GetCommentsByDate(DateTime startDate, DateTime endDate);

        IEnumerable<Comment> GetCommentsByKeywords(string keywords);

        IEnumerable<Comment> GetCommentsByPhoto(Photo photo);
    }
}
