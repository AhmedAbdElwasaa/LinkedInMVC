namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company Size",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Industry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Company", "Size", c => c.String());
            AddColumn("dbo.Company", "CompanySize_Id", c => c.Int());
            AddColumn("dbo.Company", "CompanyType_Id", c => c.Int());
            AddColumn("dbo.Company", "Industry_Id", c => c.Int());
            CreateIndex("dbo.Company", "CompanySize_Id");
            CreateIndex("dbo.Company", "CompanyType_Id");
            CreateIndex("dbo.Company", "Industry_Id");
            AddForeignKey("dbo.Company", "CompanySize_Id", "dbo.Company Size", "Id");
            AddForeignKey("dbo.Company", "CompanyType_Id", "dbo.Company Type", "Id");
            AddForeignKey("dbo.Company", "Industry_Id", "dbo.Industry", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Company", "Industry_Id", "dbo.Industry");
            DropForeignKey("dbo.Company", "CompanyType_Id", "dbo.Company Type");
            DropForeignKey("dbo.Company", "CompanySize_Id", "dbo.Company Size");
            DropIndex("dbo.Company", new[] { "Industry_Id" });
            DropIndex("dbo.Company", new[] { "CompanyType_Id" });
            DropIndex("dbo.Company", new[] { "CompanySize_Id" });
            DropColumn("dbo.Company", "Industry_Id");
            DropColumn("dbo.Company", "CompanyType_Id");
            DropColumn("dbo.Company", "CompanySize_Id");
            DropColumn("dbo.Company", "Size");
            DropTable("dbo.Industry");
            DropTable("dbo.Company Type");
            DropTable("dbo.Company Size");
        }
    }
}
