namespace Photocom.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLikesModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Photo_Id" });
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Photo_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.Users", "Photo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Photo_Id", c => c.Int());
            DropForeignKey("dbo.Likes", "User_Id", "dbo.Users");
            DropIndex("dbo.Likes", new[] { "User_Id" });
            DropIndex("dbo.Likes", new[] { "Photo_Id" });
            DropTable("dbo.Likes");
            CreateIndex("dbo.Users", "Photo_Id");
        }
    }
}
