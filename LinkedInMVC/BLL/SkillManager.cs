using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class SkillManager : Repository<Skill , ApplicationDbContext>
    {
        private readonly ApplicationDbContext context;
        public SkillManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;

        }
    }
}