using LinkedInMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedInMVC.Controllers
{
    public class EndorsementsController : Controller
    {
        // GET: Endorsements
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create(Endorsement endorsement)
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = UnitofWork.UserManager.FindById(userId);
            endorsement.Fk_EndorsedByUserID.Id = userId;
            //endorsement.Fk_EndorsedUserID=

            if (ModelState.IsValid)
            {
                endorsement = UnitofWork.EndorsementManager.Add(endorsement);
               



            }
            return RedirectToAction("Index", "Profile");
        }
    }
}