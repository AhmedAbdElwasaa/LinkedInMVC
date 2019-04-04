namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Company", name: "Inustry", newName: "Industry");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Company", name: "Industry", newName: "Inustry");
        }
    }
}
