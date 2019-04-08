using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public bool AddCompany(ApplicationUser userId, Company company)
        {
            // try
            // {
            UserCompany uc = new UserCompany();
            uc.Company = company;
            uc.ApplicationUser = userId;
            context.UserCompany.Add(uc);
            return context.SaveChanges() > 0;

            // } catch(DbEntityValidationException e )
            // {
            //    Exception raise = e;
            //  foreach (var eve in e.EntityValidationErrors)
            //  {

            //     foreach (var ve in eve.ValidationErrors)
            //    {
            //      string message = string.Format("{0}:{1}",eve.Entry.Entity.ToString(),ve.ErrorMessage);
            //     raise = new InvalidOperationException(message, raise);

            //                    }

            //  }

            //  throw raise;
            // }

            //public void AddCompany(string userId,Company company)
            //{
            //    UserCompany uc = new UserCompany();
            //    uc.ApplicationUser.Id = userId;
            //    uc.Company.Id = company.Id;
            //    context.UserCompany.Add(uc);
            //    context.SaveChanges();
       // }

        }
    }
}