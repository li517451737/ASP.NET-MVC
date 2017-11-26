namespace TP.EntityFrameworkCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Guid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Guid");
        }
    }
}
