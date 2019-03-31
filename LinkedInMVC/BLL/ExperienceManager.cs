using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Managers
{
    public class ExperienceManager : Repository<Experience, ApplicationDbContext>
    {
        private readonly ApplicationDbContext context;

        public ExperienceManager(ApplicationDbContext context) : base(context)
        {
            context = this.context;

        }
    }
}