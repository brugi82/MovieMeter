namespace MovieMeter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_double_id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "OnDemandStarts", c => c.DateTime());
            AddColumn("dbo.Programs", "OnDemandEnds", c => c.DateTime());
            DropColumn("dbo.Programs", "UpdateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programs", "UpdateId", c => c.Int(nullable: false));
            DropColumn("dbo.Programs", "OnDemandEnds");
            DropColumn("dbo.Programs", "OnDemandStarts");
        }
    }
}
