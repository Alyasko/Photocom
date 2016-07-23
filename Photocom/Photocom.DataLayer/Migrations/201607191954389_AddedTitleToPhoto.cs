namespace Photocom.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitleToPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "Title");
        }
    }
}
