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
    public class NetworkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }

        // GET: Network
        public ActionResult Index()
        {
            List<ApplicationUser> matualFreind = UnitofWork.ConnectionManager.
                           GetMetualFriend(User.Identity.GetUserId());
            List<ConnectionViewModel> cvm = matualFreind.Select(c => new ConnectionViewModel
            { FirstName = c.FirstName, UserId = c.Id, ImageUrl = c.ProfileImage, CoverUrl = c.ProfileCover })
            .ToList();


            List<ApplicationUser> FreiendRequset = UnitofWork.ConnectionManager.GetAllFriendRequest(User.Identity.GetUserId());
            List<ConnectionViewModel> cvm2 = FreiendRequset.Select(c => new ConnectionViewModel
            { FirstName = c.FirstName, UserId = c.Id, ImageUrl = c.ProfileImage, CoverUrl = c.ProfileCover })
           .ToList();

            NetworkViewModel cvm3 = new NetworkViewModel();
            cvm3.MetualFriend = cvm;
            cvm3.FriendRequest = cvm2;
            return View(cvm3);
        }
        public ActionResult Add(string Id)
        {

            UnitofWork.ConnectionManager.
                           AddFriendRequest(User.Identity.GetUserId(), Id);


            return RedirectToAction("Index");
        }

        public ActionResult Accept(string id)
        {
            UnitofWork.ConnectionManager.
                           AcceptFriendRequest(id, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }

        public ActionResult Ignore(string id)
        {
            UnitofWork.ConnectionManager.
                           DeleteFriend(id, User.Identity.GetUserId());
            return RedirectToAction("Index");
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




    }
}
