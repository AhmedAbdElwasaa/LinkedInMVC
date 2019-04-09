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
        private readonly ApplicationDbContext context;
        public UserCompanyManager(ApplicationDbContext context) :base(context)
        {
            this.context = context;
        }


        public void AddCompany(string userId,Company company)
        {
            UserCompany uc = new UserCompany();
            uc.ApplicationUser.Id = userId;
            uc.Company.Id = company.Id;
            context.UserCompany.Add(uc);
            context.SaveChanges();
        }
    }
}