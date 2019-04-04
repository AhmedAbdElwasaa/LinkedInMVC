namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fk_PostId = c.Int(nullable: false),
                        CommentText = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Post", t => t.Fk_PostId, cascadeDelete: true)
                .Index(t => t.Fk_PostId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        postText = c.String(),
                        Date = c.DateTime(nullable: false),
                        numOfLikes = c.Int(nullable: false),
                        numOfComments = c.Int(nullable: false),
                        numOfShares = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Post_Shared_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Post", t => t.Post_Shared_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Post_Shared_Id);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fk_PostId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Post", t => t.Fk_PostId, cascadeDelete: true)
                .Index(t => t.Fk_PostId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Connection_Request",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsApproved = c.Boolean(nullable: false),
                        FK_Connction_UserId_Id = c.String(maxLength: 128),
                        FK_UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FK_Connction_UserId_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FK_UserId_Id)
                .Index(t => t.FK_Connction_UserId_Id)
                .Index(t => t.FK_UserId_Id);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                        Degree = c.String(),
                        FieldOfStudy = c.String(),
                        Grade = c.String(),
                        FromYear = c.Int(nullable: false),
                        ToYear = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEducation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Education_Id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Education", t => t.Education_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.Education_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Company = c.String(),
                        Location = c.String(),
                        FromYear = c.Int(nullable: false),
                        ToYear = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserExperience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Experience_Id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Experience", t => t.Experience_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.Experience_Id)
                .Index(t => t.UserId_Id);
            
            AddColumn("dbo.AspNetUsers", "ProfileImage", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfileCover", c => c.String());
            AddColumn("dbo.AspNetUsers", "CurrentCopmany", c => c.String());
            AddColumn("dbo.AspNetUsers", "Headline", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "NumOfConnections", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserExperience", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserExperience", "Experience_Id", "dbo.Experience");
            DropForeignKey("dbo.UserEducation", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEducation", "Education_Id", "dbo.Education");
            DropForeignKey("dbo.Connection_Request", "FK_UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Connection_Request", "FK_Connction_UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comment", "Fk_PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Post", "Post_Shared_Id", "dbo.Post");
            DropForeignKey("dbo.Like", "Fk_PostId", "dbo.Post");
            DropForeignKey("dbo.Like", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Post", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserExperience", new[] { "UserId_Id" });
            DropIndex("dbo.UserExperience", new[] { "Experience_Id" });
            DropIndex("dbo.UserEducation", new[] { "UserId_Id" });
            DropIndex("dbo.UserEducation", new[] { "Education_Id" });
            DropIndex("dbo.Connection_Request", new[] { "FK_UserId_Id" });
            DropIndex("dbo.Connection_Request", new[] { "FK_Connction_UserId_Id" });
            DropIndex("dbo.Like", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Like", new[] { "Fk_PostId" });
            DropIndex("dbo.Post", new[] { "Post_Shared_Id" });
            DropIndex("dbo.Post", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Comment", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Comment", new[] { "Fk_PostId" });
            DropColumn("dbo.AspNetUsers", "NumOfConnections");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Headline");
            DropColumn("dbo.AspNetUsers", "CurrentCopmany");
            DropColumn("dbo.AspNetUsers", "ProfileCover");
            DropColumn("dbo.AspNetUsers", "ProfileImage");
            DropTable("dbo.UserExperience");
            DropTable("dbo.Experience");
            DropTable("dbo.UserEducation");
            DropTable("dbo.Education");
            DropTable("dbo.Connection_Request");
            DropTable("dbo.Like");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
