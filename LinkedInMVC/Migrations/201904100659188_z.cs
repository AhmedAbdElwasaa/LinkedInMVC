namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class z : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Company Size", newName: "Company_Size");
            RenameTable(name: "dbo.Company Type", newName: "Company_Type");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Company_Type", newName: "Company Type");
            RenameTable(name: "dbo.Company_Size", newName: "Company Size");
        }
    }
}
