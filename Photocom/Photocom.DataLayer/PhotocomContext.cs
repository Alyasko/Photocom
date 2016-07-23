using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Photocom.Models.Entities.Database;

namespace Photocom.DataLayer
{
    public class PhotocomContext : DbContext
    {
        public PhotocomContext()
        {
            Database.SetInitializer<PhotocomContext>(new PhotocomDatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Comment>().HasKey(x => x.Id);
            modelBuilder.Entity<Permission>().HasKey(x => x.Id);
            modelBuilder.Entity<Photo>().HasKey(x => x.Id);
            modelBuilder.Entity<Privilege>().HasKey(x => x.Id);
            modelBuilder.Entity<HashTag>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Like>().HasKey(x => x.Id);
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Photo> Photos { get; set; }  

        public DbSet<Category> Categories { get; set; }
         
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Session> Sessions { get; set; } 

        public DbSet<Like> Likes { get; set; } 

        //public DbSet<PermissionEntry> Permissions { get; set; }

        //public DbSet<PrivilegeEntry> Privileges { get; set; }

    }
}
