using LinkedInMVC.Models;
using LinkedInMVC.Repository;
using Microsoft.AspNet.Identity.Owin;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedInMVC.BLL
{
    public class IndustryManager:Repository<Industry,ApplicationDbContext>
    {
        private readonly ApplicationDbContext context;
        public IndustryManager(ApplicationDbContext context):base(context)
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