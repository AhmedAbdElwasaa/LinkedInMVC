
﻿using System;
﻿using LinkedInMVC.Models;
using Microsoft.AspNet.Identity.Owin;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedInMVC.Controllers
{
    public class ConnectionController : Controller
    {
        // GET: Connection

        public ActionResult Index()
        {
            return View();
        }

        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }
        
    }
}