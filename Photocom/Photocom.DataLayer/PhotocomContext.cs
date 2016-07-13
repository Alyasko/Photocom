using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Photocom.DataLayer.Entries;

namespace Photocom.DataLayer
{
    public class PhotocomContext : DbContext
    {
        public PhotocomContext()
        {
            
        }

        public DbSet<UserEntry> Users { get; set; }
        
        public DbSet<PhotoEntry> Photos { get; set; }  

        public DbSet<CategoryEntry> Categories { get; set; }
         
        public DbSet<CommentEntry> Comments { get; set; }

        //public DbSet<PermissionEntry> Permissions { get; set; }

        //public DbSet<PrivilegeEntry> Privileges { get; set; }

    }
}
