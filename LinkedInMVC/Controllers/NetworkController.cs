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

namespace LinkedInMVC.Controllers
{
    public class NetworkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Network
        public async Task<ActionResult> Index()
        {
            return View(await db.Connection_Requeset.ToListAsync());
        }

        // GET: Network/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connection_Request connection_Request = await db.Connection_Requeset.FindAsync(id);
            if (connection_Request == null)
            {
                return HttpNotFound();
            }
            return View(connection_Request);
        }

        // GET: Network/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Network/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IsApproved")] Connection_Request connection_Request)
        {
            if (ModelState.IsValid)
            {
                db.Connection_Requeset.Add(connection_Request);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(connection_Request);
        }

        // GET: Network/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connection_Request connection_Request = await db.Connection_Requeset.FindAsync(id);
            if (connection_Request == null)
            {
                return HttpNotFound();
            }
            return View(connection_Request);
        }

        // POST: Network/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IsApproved")] Connection_Request connection_Request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(connection_Request).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(connection_Request);
        }

        // GET: Network/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connection_Request connection_Request = await db.Connection_Requeset.FindAsync(id);
            if (connection_Request == null)
            {
                return HttpNotFound();
            }
            return View(connection_Request);
        }

        // POST: Network/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Connection_Request connection_Request = await db.Connection_Requeset.FindAsync(id);
            db.Connection_Requeset.Remove(connection_Request);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
