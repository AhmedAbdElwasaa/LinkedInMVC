namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Job", "CompanyFK", "dbo.Company");
            DropIndex("dbo.Job", new[] { "CompanyFK" });
            RenameColumn(table: "dbo.Job", name: "IndustryFK_Id", newName: "Industry_Id");
            RenameIndex(table: "dbo.Job", name: "IX_IndustryFK_Id", newName: "IX_Industry_Id");
            AddColumn("dbo.Job", "IndustryFK", c => c.Int());
            AlterColumn("dbo.Job", "CompanyFK", c => c.Int());
            CreateIndex("dbo.Job", "CompanyFK");
            AddForeignKey("dbo.Job", "CompanyFK", "dbo.Company", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Job", "CompanyFK", "dbo.Company");
            DropIndex("dbo.Job", new[] { "CompanyFK" });
            AlterColumn("dbo.Job", "CompanyFK", c => c.Int(nullable: false));
            DropColumn("dbo.Job", "IndustryFK");
            RenameIndex(table: "dbo.Job", name: "IX_Industry_Id", newName: "IX_IndustryFK_Id");
            RenameColumn(table: "dbo.Job", name: "Industry_Id", newName: "IndustryFK_Id");
            CreateIndex("dbo.Job", "CompanyFK");
            AddForeignKey("dbo.Job", "CompanyFK", "dbo.Company", "Id", cascadeDelete: true);
        }
    }
}
