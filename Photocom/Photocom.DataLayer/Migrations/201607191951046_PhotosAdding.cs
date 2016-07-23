namespace Photocom.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotosAdding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HashTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Photo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.Photo_Id)
                .Index(t => t.Photo_Id);
            
            AddColumn("dbo.Photos", "Path", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HashTags", "Photo_Id", "dbo.Photos");
            DropIndex("dbo.HashTags", new[] { "Photo_Id" });
            DropColumn("dbo.Photos", "Path");
            DropTable("dbo.HashTags");
        }
    }
}
