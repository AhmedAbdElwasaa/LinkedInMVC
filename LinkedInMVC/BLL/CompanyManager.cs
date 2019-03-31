using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    //                          company manager
    public class CompanyManager:Repository<Company,ApplicationDbContext>
    {
        public CompanyManager(ApplicationDbContext context) : base(context)
        {

        }
    }
}