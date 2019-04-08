namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSkill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Skill_Id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skill", t => t.Skill_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.Skill_Id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSkill", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSkill", "Skill_Id", "dbo.Skill");
            DropIndex("dbo.UserSkill", new[] { "UserId_Id" });
            DropIndex("dbo.UserSkill", new[] { "Skill_Id" });
            DropTable("dbo.UserSkill");
            DropTable("dbo.Skill");
        }
    }
}
