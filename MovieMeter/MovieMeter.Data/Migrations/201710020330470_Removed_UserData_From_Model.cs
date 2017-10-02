namespace MovieMeter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_UserData_From_Model : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Programs", "Watched");
            DropColumn("dbo.Programs", "UserRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programs", "UserRating", c => c.Double(nullable: false));
            AddColumn("dbo.Programs", "Watched", c => c.Boolean(nullable: false));
        }
    }
}
