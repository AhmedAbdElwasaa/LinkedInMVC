namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class farouk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Job_Industry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndustryFk_Id = c.Int(),
                        JobFk_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Industry", t => t.IndustryFk_Id)
                .ForeignKey("dbo.Job", t => t.JobFk_Id)
                .Index(t => t.IndustryFk_Id)
                .Index(t => t.JobFk_Id);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JobDate = c.DateTime(nullable: false),
                        JobFunction = c.String(),
                        JobDescription = c.String(),
                        CompanyFK = c.Int(nullable: false),
                        IndustryFK_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyFK, cascadeDelete: true)
                .ForeignKey("dbo.Industry", t => t.IndustryFK_Id)
                .Index(t => t.CompanyFK)
                .Index(t => t.IndustryFK_Id);
            
            CreateTable(
                "dbo.Employment_Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        JobFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Job", t => t.JobFK, cascadeDelete: true)
                .Index(t => t.JobFK);
            
            CreateTable(
                "dbo.Seniority",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(),
                        JobFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Job", t => t.JobFK, cascadeDelete: true)
                .Index(t => t.JobFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seniority", "JobFK", "dbo.Job");
            DropForeignKey("dbo.Job_Industry", "JobFk_Id", "dbo.Job");
            DropForeignKey("dbo.Job", "IndustryFK_Id", "dbo.Industry");
            DropForeignKey("dbo.Employment_Type", "JobFK", "dbo.Job");
            DropForeignKey("dbo.Job", "CompanyFK", "dbo.Company");
            DropForeignKey("dbo.Job_Industry", "IndustryFk_Id", "dbo.Industry");
            DropIndex("dbo.Seniority", new[] { "JobFK" });
            DropIndex("dbo.Employment_Type", new[] { "JobFK" });
            DropIndex("dbo.Job", new[] { "IndustryFK_Id" });
            DropIndex("dbo.Job", new[] { "CompanyFK" });
            DropIndex("dbo.Job_Industry", new[] { "JobFk_Id" });
            DropIndex("dbo.Job_Industry", new[] { "IndustryFk_Id" });
            DropTable("dbo.Seniority");
            DropTable("dbo.Employment_Type");
            DropTable("dbo.Job");
            DropTable("dbo.Job_Industry");
        }
    }
}
