using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class CompanySizeManager:Repository<CompanySize,ApplicationDbContext>
    {
        private readonly ApplicationDbContext context;
        public CompanySizeManager(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }
    }
}