namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rttt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "Name", c => c.String());
        }
    }
}
