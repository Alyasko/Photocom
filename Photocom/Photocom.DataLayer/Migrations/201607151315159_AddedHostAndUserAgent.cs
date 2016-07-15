namespace Photocom.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHostAndUserAgent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "UserAgent", c => c.String());
            AddColumn("dbo.Sessions", "Host", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sessions", "Host");
            DropColumn("dbo.Sessions", "UserAgent");
        }
    }
}
