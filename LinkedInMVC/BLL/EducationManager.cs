using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class EducationManager : Repository<Education, ApplicationDbContext>
    {
        private readonly ApplicationDbContext context;
        public EducationManager(ApplicationDbContext context) : base(context)
        {
            context = this.context;

        }
        public  bool AddEducation(Education education, ApplicationUser userId)
        {
            context.Educations.Add(education);
            return true;
        }
    }
}