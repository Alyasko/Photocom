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
    public class CommentRepository : AbstractRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Comment> GetCommentsByUser(User user)
        {
            return DbContext.Set<Comment>().Where(x => x.Author == user).ToList();
        }

        public IEnumerable<Comment> GetCommentsByDate(DateTime date)
        {
            return DbContext.Set<Comment>().Where(x => x.DateAdded == date).ToList();
        }

        public IEnumerable<Comment> GetCommentsByDate(DateTime startDate, DateTime endDate)
        {
            return DbContext.Set<Comment>().Where(x => x.DateAdded >= startDate && x.DateAdded <= endDate).ToList();
        }

        public IEnumerable<Comment> GetCommentsByKeywords(string keywords)
        {
            return DbContext.Set<Comment>().Where(x => x.Text.Contains(keywords)).ToList();
        }

        public IEnumerable<Comment> GetCommentsByPhoto(Photo photo)
        {
            return DbContext.Set<Photo>().First(x => x == photo).Comments.ToList();
        }
    }
}
