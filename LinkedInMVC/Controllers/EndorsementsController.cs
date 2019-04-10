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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create(int id , string EId)
        {
            Endorsement endorsement = new Endorsement();

            Skill skill = UnitofWork.SkillManager.GetById(id);
            endorsement.FK_SkillId = skill;
          
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = UnitofWork.UserManager.FindById(userId);
            ApplicationUser Endorsed = UnitofWork.UserManager.FindById(EId);

            endorsement.Fk_EndorsedByUserID = currentUser;
            endorsement.Fk_EndorsedUserID = Endorsed;
            //endorsement.Fk_EndorsedUserID=

            if (ModelState.IsValid)
            {
                endorsement = UnitofWork.EndorsementManager.Add(endorsement);
               



            }
            return RedirectToAction("Index", "Profile");
        }
    }
}