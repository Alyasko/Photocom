using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Contracts.Repositories;

namespace Photocom.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        void SaveChanges();

        ICategoryRepository CategoryRepository { get; }

        ICommentRepository CommentRepository { get; }

        IPermissionRepository PermissionRepository { get; }

        IPhotoRepository PhotoRepository { get; }

        IPrivilegeRepository PrivilegeRepository { get; }

        IUserRepository UserRepository { get; }
    }
}
