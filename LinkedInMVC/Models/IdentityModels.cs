using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LinkedInMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser 
    {
<<<<<<< HEAD
        public ApplicationUser()
        {
            this.UserCompanies = new HashSet<UserCompany>();
        }
        
=======
>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string ProfileImage { get; set; }

        public string ProfileCover { get; set; }

        public string CurrentCopmany { get; set; }
        public string Headline { get; set; }
        public string Country { get; set; }
        public int NumOfConnections { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
        public ICollection<UserEducation> UserEducations = new List<UserEducation>();
        public ICollection<UserExperience> UserExperiences = new List<UserExperience>();
        public ICollection<Connection_Request> Connection_Requeset = new List<Connection_Request>();
        public ICollection<Connection_Request> Connection_Requeset1 = new List<Connection_Request>();
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
      
        public DbSet<Company> Company { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }
        public DbSet<Industry> Industry { get; set; }
        public DbSet<CompanySize> CompanySize { get; set; }
        public DbSet<CompanyType> CompanyType { get; set; }




        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public DbSet<Education> Education { get; set; }
         public DbSet<UserEducation> UserEducation { get; set; }
      
        public DbSet<Experience> Experience { get; set; }
        public DbSet<UserExperience> UserExperiences { get; set; }

        //CONNECTION
        public DbSet<Connection_Request> Connection_Requeset { get; set; }
       



    }
}