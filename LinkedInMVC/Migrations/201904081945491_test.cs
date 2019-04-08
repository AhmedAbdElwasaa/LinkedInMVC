namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endorsement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fk_EndorsedByUserID_Id = c.String(maxLength: 128),
                        Fk_EndorsedUserID_Id = c.String(maxLength: 128),
                        FK_SkillId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Fk_EndorsedByUserID_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Fk_EndorsedUserID_Id)
                .ForeignKey("dbo.Skill", t => t.FK_SkillId_Id)
                .Index(t => t.Fk_EndorsedByUserID_Id)
                .Index(t => t.Fk_EndorsedUserID_Id)
                .Index(t => t.FK_SkillId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endorsement", "FK_SkillId_Id", "dbo.Skill");
            DropForeignKey("dbo.Endorsement", "Fk_EndorsedUserID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Endorsement", "Fk_EndorsedByUserID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Endorsement", new[] { "FK_SkillId_Id" });
            DropIndex("dbo.Endorsement", new[] { "Fk_EndorsedUserID_Id" });
            DropIndex("dbo.Endorsement", new[] { "Fk_EndorsedByUserID_Id" });
            DropTable("dbo.Endorsement");
        }
    }
}
