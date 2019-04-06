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

        // GET: Educations
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Educations.ToListAsync());
        //}

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

        //// GET: Educations/Create
        public ActionResult Create()
        {

            return View();
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
             education=  UnitofWork.EducationManager.Add(education);
              UnitofWork.UserEducationManager.AddUserEducation(education, currentUser);
                
              
            }

            return RedirectToAction( "Index","Profile");
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

        //// POST: Educations/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,SchoolName,Degree,FieldOfStudy,Grade,FromYear,ToYear")] Education education)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(education).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(education);
        //}

        //// GET: Educations/Delete/5
        //public async Task<ActionResult> Delete(int? id)
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

        //// POST: Educations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Education education = await db.Educations.FindAsync(id);
        //    db.Educations.Remove(education);
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
