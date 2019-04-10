using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinkedInMVC.Models;
using Microsoft.AspNet.Identity.Owin;
using LinkedInMVC.ViewModel;
using Microsoft.AspNet.Identity;

namespace LinkedInMVC.Controllers
{
    public class EducationsController : Controller
    {
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }

        //// POST: Educations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Education education)
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = UnitofWork.UserManager.FindById(userId);

            if (ModelState.IsValid)
            {
                education = UnitofWork.EducationManager.Add(education);
                UnitofWork.UserEducationManager.AddUserEducation(education, currentUser);

             

            }

            
            return RedirectToAction("Index", "Profile");
        }

      

        //// GET: Educations/Details/5
        public async Task<ActionResult> Details(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<EducationViewModel> Educations =  UnitofWork.UserEducationManager.GetUserEducations(id);
            if (Educations == null)
            {
                return HttpNotFound();
            }
            return View(Educations);
        }


        // POST: Educations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Education education)
        {
            if (ModelState.IsValid)
            {
               

                UnitofWork.EducationManager.Update(education);

            }
                return RedirectToAction("Index", "Profile");
         
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = UnitofWork.UserManager.FindById(userId);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education =  UnitofWork.EducationManager.GetById(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            else
            {
                UnitofWork.UserEducationManager.DeleteUserEducation(education, currentUser);
            }
            return RedirectToAction("Index", "Profile");
        }





        //// GET: Educations/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Education education = await db.Educations.FindAsync(id);
        //    if (education == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(education);
        //}





        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
