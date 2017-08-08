namespace MovieMeter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Genre = c.String(),
                        Plot = c.String(),
                        Actors = c.String(),
                        ImdbRating = c.Single(nullable: false),
                        ImdbVotes = c.Int(nullable: false),
                        Source = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Programs");
        }
    }
}
