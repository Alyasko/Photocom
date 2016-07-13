﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photocom.Contracts;
using Photocom.Contracts.Repositories;
using Photocom.DataLayer.Repositories;

namespace Photocom.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        protected PhotocomContext PhotocomContext;

        private ICategoryRepository _categoryRepository;
        private ICommentRepository _commentRepository;
        private IPermissionRepository _permissionRepository;
        private IPhotoRepository _photoRepository;
        private IPrivilegeRepository _privilegeRepository;
        private IUserRepository _userRepository;

        public UnitOfWork()
        {
            PhotocomContext = new PhotocomContext();
        }

        public void SaveChanges()
        {
            PhotocomContext.SaveChanges();

            _categoryRepository = null;
            _commentRepository = null;
            _permissionRepository = null;
            _photoRepository = null;
            _privilegeRepository = null;
            _userRepository = null;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(PhotocomContext);
                }
                return _categoryRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(PhotocomContext);
                }
                return _commentRepository;
            }
        }

        public IPermissionRepository PermissionRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(PhotocomContext);
                }
                return _permissionRepository;
            }
        }

        public IPhotoRepository PhotoRepository
        {
            get
            {
                if (_photoRepository == null)
                {
                    _photoRepository = new PhotoRepository(PhotocomContext);
                }
                return _photoRepository;
            }
        }

        public IPrivilegeRepository PrivilegeRepository
        {
            get
            {
                if (_privilegeRepository == null)
                {
                    _privilegeRepository = new PrivilegeRepository(PhotocomContext);
                }
                return _privilegeRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(PhotocomContext);
                }
                return _userRepository;
            }
        }

        public void Dispose()
        {
            PhotocomContext.Dispose();
        }

        public void Seed()
        {
            
        }
    }
}