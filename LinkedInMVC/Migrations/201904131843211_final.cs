namespace LinkedInMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        ProfileImage = c.String(),
                        ProfileCover = c.String(),
                        CurrentCopmany = c.String(),
                        Headline = c.String(),
                        Country = c.String(),
                        NumOfConnections = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.User_Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        URL = c.String(),
                        Logo = c.String(),
                        Cover = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                        Industry_FKId = c.Int(),
                        CompanySize_Id = c.Int(),
                        CompanyType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company_Size", t => t.CompanySize_Id)
                .ForeignKey("dbo.Company_Type", t => t.CompanyType_Id)
                .ForeignKey("dbo.Industry", t => t.Industry_FKId)
                .Index(t => t.Industry_FKId)
                .Index(t => t.CompanySize_Id)
                .Index(t => t.CompanyType_Id);
            
            CreateTable(
                "dbo.Company_Size",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company_Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Industry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JobDate = c.DateTime(nullable: false),
                        JobFunction = c.String(),
                        JobDescription = c.String(),
                        IndustryFK = c.Int(),
                        CompanyFK = c.Int(),
                        Industry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyFK)
                .ForeignKey("dbo.Industry", t => t.Industry_Id)
                .Index(t => t.CompanyFK)
                .Index(t => t.Industry_Id);
            
            CreateTable(
                "dbo.Employment_Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        JobFK = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Job", t => t.JobFK)
                .Index(t => t.JobFK);
            
            CreateTable(
                "dbo.Job_Industry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndustryFk_Id = c.Int(),
                        JobFk_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Industry", t => t.IndustryFk_Id)
                .ForeignKey("dbo.Job", t => t.JobFk_Id)
                .Index(t => t.IndustryFk_Id)
                .Index(t => t.JobFk_Id);
            
            CreateTable(
                "dbo.Seniority",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(),
                        JobFK = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Job", t => t.JobFK)
                .Index(t => t.JobFK);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserExperience", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserExperience", "Experience_Id", "dbo.Experience");
            DropForeignKey("dbo.Endorsement", "FK_SkillId_Id", "dbo.Skill");
            DropForeignKey("dbo.UserSkill", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSkill", "Skill_Id", "dbo.Skill");
            DropForeignKey("dbo.Endorsement", "Fk_EndorsedUserID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Endorsement", "Fk_EndorsedByUserID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEducation", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEducation", "Education_Id", "dbo.Education");
            DropForeignKey("dbo.Connection_Request", "FK_UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Connection_Request", "FK_Connction_UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comment", "Fk_PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.User_Company", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Seniority", "JobFK", "dbo.Job");
            DropForeignKey("dbo.Job_Industry", "JobFk_Id", "dbo.Job");
            DropForeignKey("dbo.Job_Industry", "IndustryFk_Id", "dbo.Industry");
            DropForeignKey("dbo.Job", "Industry_Id", "dbo.Industry");
            DropForeignKey("dbo.Employment_Type", "JobFK", "dbo.Job");
            DropForeignKey("dbo.Job", "CompanyFK", "dbo.Company");
            DropForeignKey("dbo.Company", "Industry_FKId", "dbo.Industry");
            DropForeignKey("dbo.Company", "CompanyType_Id", "dbo.Company_Type");
            DropForeignKey("dbo.Company", "CompanySize_Id", "dbo.Company_Size");
            DropForeignKey("dbo.User_Company", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Post", "Post_Shared_Id", "dbo.Post");
            DropForeignKey("dbo.Like", "Fk_PostId", "dbo.Post");
            DropForeignKey("dbo.Like", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Post", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserExperience", new[] { "UserId_Id" });
            DropIndex("dbo.UserExperience", new[] { "Experience_Id" });
            DropIndex("dbo.UserSkill", new[] { "UserId_Id" });
            DropIndex("dbo.UserSkill", new[] { "Skill_Id" });
            DropIndex("dbo.Endorsement", new[] { "FK_SkillId_Id" });
            DropIndex("dbo.Endorsement", new[] { "Fk_EndorsedUserID_Id" });
            DropIndex("dbo.Endorsement", new[] { "Fk_EndorsedByUserID_Id" });
            DropIndex("dbo.UserEducation", new[] { "UserId_Id" });
            DropIndex("dbo.UserEducation", new[] { "Education_Id" });
            DropIndex("dbo.Connection_Request", new[] { "FK_UserId_Id" });
            DropIndex("dbo.Connection_Request", new[] { "FK_Connction_UserId_Id" });
            DropIndex("dbo.Seniority", new[] { "JobFK" });
            DropIndex("dbo.Job_Industry", new[] { "JobFk_Id" });
            DropIndex("dbo.Job_Industry", new[] { "IndustryFk_Id" });
            DropIndex("dbo.Employment_Type", new[] { "JobFK" });
            DropIndex("dbo.Job", new[] { "Industry_Id" });
            DropIndex("dbo.Job", new[] { "CompanyFK" });
            DropIndex("dbo.Company", new[] { "CompanyType_Id" });
            DropIndex("dbo.Company", new[] { "CompanySize_Id" });
            DropIndex("dbo.Company", new[] { "Industry_FKId" });
            DropIndex("dbo.User_Company", new[] { "Company_Id" });
            DropIndex("dbo.User_Company", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Like", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Like", new[] { "Fk_PostId" });
            DropIndex("dbo.Post", new[] { "Post_Shared_Id" });
            DropIndex("dbo.Post", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comment", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Comment", new[] { "Fk_PostId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserExperience");
            DropTable("dbo.Experience");
            DropTable("dbo.UserSkill");
            DropTable("dbo.Skill");
            DropTable("dbo.Endorsement");
            DropTable("dbo.UserEducation");
            DropTable("dbo.Education");
            DropTable("dbo.Connection_Request");
            DropTable("dbo.Seniority");
            DropTable("dbo.Job_Industry");
            DropTable("dbo.Employment_Type");
            DropTable("dbo.Job");
            DropTable("dbo.Industry");
            DropTable("dbo.Company_Type");
            DropTable("dbo.Company_Size");
            DropTable("dbo.Company");
            DropTable("dbo.User_Company");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Like");
            DropTable("dbo.Post");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comment");
        }
    }
}
