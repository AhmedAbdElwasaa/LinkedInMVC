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
            this.context = context;

        }
        //public int AddEducation(Education education)
        //{
           
        //    context.Education.Add(education);
        //    context.SaveChanges() ;
        //    int id = education.Id;
        //    return id;
        //}
    }
}