using LinkedInMVC.BLL;
using LinkedInMVC.Managers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    public class UnitofWork
     : IDisposable
    {
        private readonly ApplicationDbContext context;
        public ApplicationRoleManager RoleManager { get; private set; }
        public ApplicationUserManager UserManager { get; private set; }
        //public CompanyManager CompanyManager { get; set; }// unit of work for company manager
        //public UserCompanyManager UserCompanyManager { get; set; }// unit of work for usercompany manager
        
        public ExperienceManager ExperienceManager
        {
            get
            {
                return new ExperienceManager(context);
            }
        }
       
        public EducationManager EducationManager
        {
            get
            {
                return new EducationManager(context);
            }
        }
        public CompanySizeManager CompanySizeManager
        {
            get
            {
                return new CompanySizeManager(context);
            }
        }
        public CompanyTypeManager CompanyTypeManager
        {
            get
            {
                return new CompanyTypeManager(context);
            }
        }
        public UserEducationManager UserEducationManager
        {
            get
            {
                return new UserEducationManager(context);
            }
        }
        public UserExperienceManager UserExperienceManager
        {
            get
            {
                return new UserExperienceManager(context);
            }
        }

        public IndustryManager IndustryManager
        {
            get
            {
                return new IndustryManager(context);
            }
        }

        public ConnectionManager ConnectionManager
        {
            get
            {
                return new ConnectionManager(context);
            }
        }
        public CompanyManager CompanyManager
        {
            get
            {
                return new CompanyManager(context);
            }
        }
        public UserCompanyManager UserCompanyManager
        {
            get
            {
                return new UserCompanyManager(context);
            }
        }

        public PostsManager PostsManager
        {
            get
            {
                return new PostsManager(context);
            }
        }
        public UnitofWork(IOwinContext owinContext)
        {
            context = owinContext.Get<ApplicationDbContext>();
            RoleManager = owinContext.Get<ApplicationRoleManager>();
            UserManager = owinContext.Get<ApplicationUserManager>();
            //CompanyManager = owinContext.Get<CompanyManager>();  // initialize company manager property
            //UserCompanyManager = owinContext.Get<UserCompanyManager>(); // initialize usercompany manager property 
        }
        public static UnitofWork Create(IdentityFactoryOptions<UnitofWork> options, IOwinContext owinContext)
        {
            return new UnitofWork(owinContext);
        }


        public void Dispose()
        {
        }
    }
}