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
using Microsoft.AspNet.Identity;
using LinkedInMVC.ViewModel;

namespace LinkedInMVC.Controllers
{
    public class SkillsController : Controller
    {
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }

        ////POST: Skills/Create
           // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
           // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
           [HttpPost]
           [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(Skill skill)
            {
                string userId = User.Identity.GetUserId();
                ApplicationUser currentUser = UnitofWork.UserManager.FindById(userId);

                if (ModelState.IsValid)
                {
                    skill = UnitofWork.SkillManager.Add(skill);
                    UnitofWork.UserSkillManager.AddUserSkill(skill, currentUser);



                }
            return RedirectToAction("Index", "Profile");
            }

        // GET: Skills/Details/5
        public async Task<ActionResult> Details(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<SkillViewModel> Skills = UnitofWork.UserSkillManager.GetUserSkills(id);
            if (Skills == null)
            {
                return HttpNotFound();
            }
            return View(Skills);
        }





        //    // GET: Skills/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //   
        //    // GET: Skills/Edit/5
        //    public async Task<ActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Skill skill = await db.skill.FindAsync(id);
        //        if (skill == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(skill);
        //    }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Skill skill)
        {
            if (ModelState.IsValid)
            {
                UnitofWork.SkillManager.Update(skill);
                
            }
            return RedirectToAction("Index", "Profile");
        }

        //    // GET: Skills/Delete/5
        //    public async Task<ActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Skill skill = await db.skill.FindAsync(id);
        //        if (skill == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(skill);
        //    }

        //    // POST: Skills/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<ActionResult> DeleteConfirmed(int id)
        //    {
        //        Skill skill = await db.skill.FindAsync(id);
        //        db.skill.Remove(skill);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}
