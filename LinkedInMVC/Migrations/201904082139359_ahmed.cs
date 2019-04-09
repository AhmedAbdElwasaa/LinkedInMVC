namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ahmed : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Company", name: "Industry_Id", newName: "Industry_FKId");
            RenameIndex(table: "dbo.Company", name: "IX_Industry_Id", newName: "IX_Industry_FKId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Company", name: "IX_Industry_FKId", newName: "IX_Industry_Id");
            RenameColumn(table: "dbo.Company", name: "Industry_FKId", newName: "Industry_Id");
        }
    }
}
