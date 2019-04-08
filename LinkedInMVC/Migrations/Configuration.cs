namespace LinkedInMVC.Migrations
{
    using LinkedInMVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LinkedInMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LinkedInMVC.Models.ApplicationDbContext context)
        {

            context.Industry.AddOrUpdate(x => x.Id,
        new Industry() { Id = 1, Name = "Accounting" },
        new Industry() { Id = 2, Name = "Airlines/Aviation" },
        new Industry() { Id = 3, Name = "Alternative Dispute Resolution" },
        new Industry() { Id = 4, Name = "Alternative Medicine" },
        new Industry() { Id = 5, Name = "Animation" },
        new Industry() { Id = 6, Name = "Apparel & Fashion" },
        new Industry() { Id = 7, Name = "Architecture & Planning" },
        new Industry() { Id = 8, Name = "Arts & Crafts" },
        new Industry() { Id = 9, Name = "Automotive" },
        new Industry() { Id = 10, Name = "Aviation & Aerospace" },
        new Industry() { Id = 11, Name = "Banking" },
        new Industry() { Id = 12, Name = "Biotechnology" },
        new Industry() { Id = 13, Name = " Information Technology & Services" },
        new Industry() { Id = 14, Name = "Internet" },
        new Industry() { Id = 15, Name = "Investment Banking" },
        new Industry() { Id = 16, Name = "Investment Management" },
        new Industry() { Id = 17, Name = "Veterinary" },
        new Industry() { Id = 18, Name = "Telecommunications" },
        new Industry() { Id = 19, Name = "Translation & Localization" }


        );

            context.CompanySize.AddOrUpdate(x => x.Id,
                new CompanySize()
                {
                    Id = 1,
                    Size= "0–1 employees"
                },
                new CompanySize()
                {
                    Id = 2,
                    Size= "2–10 employees"
                },
                new CompanySize()
                {
                    Id = 3,
                    Size= "11–50 employees"
                },
                new CompanySize()
                {
                    Id = 4,
                    Size= "51–200 employees"
                }
                );

            //context.Users.AddOrUpdate(x => x.Id,
            //    new ApplicationUser()
            //    {
            //        FirstName="Ahmed",
            //        SecondName="Abd-Elwasaa",
            //        UserName="Ahmed Abd-Elwasaa",
            //        Email="ahmedabdelwasaa@outlook.com",
            //        PasswordHash= "AHCfRHzod5yoVBbvJo2vVRobCpjbOfMCbSchC2Y3fXERHk+fGEp0LVWRVLy+vcjZZg==",
            //        SecurityStamp= "ccd82430-f36b-41e7-9ebb-d8f290a65b5d"

            //    }
                
            //    );
            context.CompanyType.AddOrUpdate(x => x.Id,
            new CompanyType()
            {
                Id = 1,
                 Type= "Public company"
            },
            new CompanyType()
            {
                Id = 2,
                Type = "Self-employed"
            },
            new CompanyType()
            {
                Id = 3,
                Type = "Government agency"
            },
            new CompanyType()
            {
                Id = 4,
                Type = "Sole proprietorship"
            },
            new CompanyType()
            {
                Id =5,
                Type = "Privately held"
            },
             new CompanyType()
             {
                 Id = 6,
                 Type = "Nonprofit"
             }, new CompanyType()
             {
                 Id = 7,
                 Type = "Privately Stablish"
             },
              new CompanyType()
              {
                  Id = 8,
                  Type = "Partnership"
              }



            );


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
