using LinkedInMVC.Models;
using LinkedInMVC.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedInMVC.Controllers
{
    public class ConnectionController : Controller
    {
        // GET: Connection
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }
        public ActionResult Index()
        {
            List<ApplicationUser> v = UnitofWork.ConnectionManager.
               GetAllFriend(User.Identity.GetUserId());
            List<ConnectionViewModel> cvm = v.Select(c => new ConnectionViewModel
            { FirstName = c.FirstName, UserId = c.Id })
            .ToList();
            return View(cvm);
        }
        //public ActionResult index()
        //{
        //    //Connection_Request v = new Connection_Request();

        //    //var u = UnitofWork.UserManager.Users.ToList();
        //    //ConnectionViewModel cvm= new ConnectionViewModel
        //    //{

        //    //     IsApproved=UnitofWork.CompanyManager

        //    //}
        //    return View(v);
        //}

    }
}