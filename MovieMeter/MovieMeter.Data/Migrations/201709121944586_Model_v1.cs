namespace MovieMeter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgramUserDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProgramId = c.String(maxLength: 128),
                        Watched = c.Boolean(nullable: false),
                        UserRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programs", t => t.ProgramId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Url = c.String(),
                        ParserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Updates",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UpdatedOn = c.DateTime(nullable: false),
                        SourceId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sources", t => t.SourceId)
                .Index(t => t.SourceId);
            
            AddColumn("dbo.Programs", "ImdbId", c => c.String());
            AddColumn("dbo.Programs", "Title", c => c.String());
            AddColumn("dbo.Programs", "Runtime", c => c.String());
            AddColumn("dbo.Programs", "Director", c => c.String());
            AddColumn("dbo.Programs", "Country", c => c.String());
            AddColumn("dbo.Programs", "Language", c => c.String());
            AddColumn("dbo.Programs", "Poster", c => c.String());
            AddColumn("dbo.Programs", "Watched", c => c.Boolean(nullable: false));
            AddColumn("dbo.Programs", "UserRating", c => c.Double(nullable: false));
            AddColumn("dbo.Programs", "SourceId", c => c.String(maxLength: 128));
            AddColumn("dbo.Programs", "UpdateId", c => c.Int(nullable: false));
            AddColumn("dbo.Programs", "Update_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Programs", "ImdbRating", c => c.Double(nullable: false));
            AlterColumn("dbo.Programs", "ImdbVotes", c => c.String());
            CreateIndex("dbo.Programs", "SourceId");
            CreateIndex("dbo.Programs", "Update_Id");
            AddForeignKey("dbo.Programs", "SourceId", "dbo.Sources", "Id");
            AddForeignKey("dbo.Programs", "Update_Id", "dbo.Updates", "Id");
            DropColumn("dbo.Programs", "Name");
            DropColumn("dbo.Programs", "Source");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programs", "Source", c => c.String());
            AddColumn("dbo.Programs", "Name", c => c.String());
            DropForeignKey("dbo.Programs", "Update_Id", "dbo.Updates");
            DropForeignKey("dbo.Updates", "SourceId", "dbo.Sources");
            DropForeignKey("dbo.Programs", "SourceId", "dbo.Sources");
            DropForeignKey("dbo.ProgramUserDatas", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProgramUserDatas", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Updates", new[] { "SourceId" });
            DropIndex("dbo.ProgramUserDatas", new[] { "ProgramId" });
            DropIndex("dbo.ProgramUserDatas", new[] { "UserId" });
            DropIndex("dbo.Programs", new[] { "Update_Id" });
            DropIndex("dbo.Programs", new[] { "SourceId" });
            AlterColumn("dbo.Programs", "ImdbVotes", c => c.Int(nullable: false));
            AlterColumn("dbo.Programs", "ImdbRating", c => c.Single(nullable: false));
            DropColumn("dbo.Programs", "Update_Id");
            DropColumn("dbo.Programs", "UpdateId");
            DropColumn("dbo.Programs", "SourceId");
            DropColumn("dbo.Programs", "UserRating");
            DropColumn("dbo.Programs", "Watched");
            DropColumn("dbo.Programs", "Poster");
            DropColumn("dbo.Programs", "Language");
            DropColumn("dbo.Programs", "Country");
            DropColumn("dbo.Programs", "Director");
            DropColumn("dbo.Programs", "Runtime");
            DropColumn("dbo.Programs", "Title");
            DropColumn("dbo.Programs", "ImdbId");
            DropTable("dbo.Updates");
            DropTable("dbo.Sources");
            DropTable("dbo.Users");
            DropTable("dbo.ProgramUserDatas");
        }
    }
}
