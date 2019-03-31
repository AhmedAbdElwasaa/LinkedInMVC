using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    //                         user company manager
    public class UserCompanyManager:Repository<UserCompany,ApplicationDbContext>
    {
        public UserCompanyManager(ApplicationDbContext context) :base(context)
        {

        }
    }
}