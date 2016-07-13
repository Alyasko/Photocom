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
    public class CommentRepository : AbstractRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Comment> GetCommentsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentsByDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentsByKeywords(string keywords)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentsByPhoto(Photo photo)
        {
            throw new NotImplementedException();
        }
    }
}
