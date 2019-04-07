using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class CompanyTypeManager:Repository<CompanyType,ApplicationDbContext>
    {
        private readonly ApplicationDbContext context;
        public CompanyTypeManager(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }
    }
}