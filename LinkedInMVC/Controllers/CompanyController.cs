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
using System.IO;
using Microsoft.AspNet.Identity;

namespace LinkedInMVC.Controllers
{
    public class CompanyController : Controller
    {
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }

        // GET: Company
        public  ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Add(Company company)
        //{
        //string fileName = Path.GetFileNameWithoutExtension(company.Logo);
        //string extension = Path.GetExtension(company.Logo);
        //fileName = fileName + extension;
        //    company.Logo = "~/images" + fileName;
        //    fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
            
        //    UnitofWork.CompanyManager.Add(company);
         

        //    ModelState.Clear();
        //    return View();
        //}

        // GET: Company/Details/5

        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Company company = await db.Company.FindAsync(id);
        //    if (company == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(company);
        //}

        // GET: Company/Create
        public ActionResult Create()
        {
            CompanyViewModel cvm = new CompanyViewModel
            {
                
                Selected = false,
                Industries = UnitofWork.IndustryManager.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(),Selected=true }).ToList(),
                Sizes=UnitofWork.CompanySizeManager.GetAll().Select(a=> new SelectListItem { Text=a.Size,Value=a.Id.ToString(),Selected=true}).ToList(),
                Types=UnitofWork.CompanyTypeManager.GetAll().Select(a=>new SelectListItem {Text=a.Type,Value=a.Id.ToString(),Selected=true }).ToList()
            };
        
            return View(cvm);
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                UserCompany userCompany = new UserCompany();
                string userId = User.Identity.GetUserId();
                ApplicationUser currentUser = UnitofWork.UserManager.FindById(userId);
                if (company.LogoFileName!=null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(company.LogoFileName.FileName);
                    string fileExtension = Path.GetExtension(company.LogoFileName.FileName);
                    fileName = DateTime.Now.ToString("yyyyMMdd") + "-" + fileName.Trim() + fileExtension;
                    company.Logo = "~/images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                    company.LogoFileName.SaveAs(fileName);
                    UnitofWork.CompanyManager.Add(company);
                    UnitofWork.UserCompanyManager.AddCompany(currentUser, company);
                    ViewBag.Message += string.Format("<b>{0}</b> Uploaded.<br/>", fileName);
                    return RedirectToAction("Index");
                }


            
                
            }
         
            return View();
        }

        // GET: Company/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    company company = await db.Company.FindAsync(id);
        //    //if (company == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    return View(company);
        //}

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,URL,Logo,Cover,Type,Industry,Address,Description")] Company company)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(company).State = EntityState.Modified;
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            return View(company);
        }

        // GET: Company/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Company company = await db.Company.FindAsync(id);
        //    if (company == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(company);
        //}

        // POST: Company/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Company company = await db.Company.FindAsync(id);
        //    db.Company.Remove(company);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitofWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
