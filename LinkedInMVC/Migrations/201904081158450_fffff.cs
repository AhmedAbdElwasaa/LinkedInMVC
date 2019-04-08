namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fffff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employment_Type", "JobFK", "dbo.Job");
            DropForeignKey("dbo.Seniority", "JobFK", "dbo.Job");
            DropIndex("dbo.Employment_Type", new[] { "JobFK" });
            DropIndex("dbo.Seniority", new[] { "JobFK" });
            AlterColumn("dbo.Employment_Type", "JobFK", c => c.Int());
            AlterColumn("dbo.Seniority", "JobFK", c => c.Int());
            CreateIndex("dbo.Employment_Type", "JobFK");
            CreateIndex("dbo.Seniority", "JobFK");
            AddForeignKey("dbo.Employment_Type", "JobFK", "dbo.Job", "Id");
            AddForeignKey("dbo.Seniority", "JobFK", "dbo.Job", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seniority", "JobFK", "dbo.Job");
            DropForeignKey("dbo.Employment_Type", "JobFK", "dbo.Job");
            DropIndex("dbo.Seniority", new[] { "JobFK" });
            DropIndex("dbo.Employment_Type", new[] { "JobFK" });
            AlterColumn("dbo.Seniority", "JobFK", c => c.Int(nullable: false));
            AlterColumn("dbo.Employment_Type", "JobFK", c => c.Int(nullable: false));
            CreateIndex("dbo.Seniority", "JobFK");
            CreateIndex("dbo.Employment_Type", "JobFK");
            AddForeignKey("dbo.Seniority", "JobFK", "dbo.Job", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employment_Type", "JobFK", "dbo.Job", "Id", cascadeDelete: true);
        }
    }
}
