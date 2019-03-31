namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CurrentCopmany", c => c.String());
            AddColumn("dbo.AspNetUsers", "Headline", c => c.String());
            AddColumn("dbo.Post", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Title", c => c.String());
            DropColumn("dbo.Post", "Date");
            DropColumn("dbo.AspNetUsers", "Headline");
            DropColumn("dbo.AspNetUsers", "CurrentCopmany");
        }
    }
}
