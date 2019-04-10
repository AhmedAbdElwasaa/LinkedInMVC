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
    public class ExperiencesController : Controller
    {
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }



        // GET: Experiences
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Experience.ToListAsync());
        //}

        public async Task<ActionResult> Details(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<ExperienceViewModel> Experiences = UnitofWork.UserExperienceManager.GetUserExperiences(id);
            if (Experiences == null)
            {
                return HttpNotFound();
            }
            return View(Experiences);
        }

        //// GET: experiences/Create
        //public ActionResult Create()
        //{

        //    return View();
        //}

        //// POST: experiences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Experience experience)
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = UnitofWork.UserManager.FindById(userId);

            if (ModelState.IsValid)
            {
                experience = UnitofWork.ExperienceManager.Add(experience);
               
                UnitofWork.UserExperienceManager.AddUserExperience(experience, currentUser);



            }

            return RedirectToAction("Index", "Profile");
        }

        //// GET: Experiences/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Experience experience = await db.Experience.FindAsync(id);
        //    if (experience == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(experience);
        //}

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Experience experience)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.ExperienceManager.Update(experience);
               
            }
            return RedirectToAction("Index", "Profile");
        }

        //// GET: Experiences/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Experience experience = await db.Experience.FindAsync(id);
        //    if (experience == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(experience);
        //}

        //// POST: Experiences/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Experience experience = await db.Experience.FindAsync(id);
        //    db.Experience.Remove(experience);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
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
