using LinkedInMVC.Models;
using Microsoft.AspNet.Identity.Owin;
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
        private readonly ApplicationDbContext context;
        public CompanyManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Get<UnitofWork>();
            }
        }



    }
}