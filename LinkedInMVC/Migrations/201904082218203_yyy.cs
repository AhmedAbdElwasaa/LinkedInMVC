namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yyy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "Logo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "Logo", c => c.String(nullable: false));
        }
    }
}
