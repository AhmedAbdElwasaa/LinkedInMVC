using LinkedInMVC.Models;
using LinkedInMVC.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            { FirstName = c.FirstName, UserId = c.Id ,ImageUrl=c.ProfileImage})
            .ToList();
            return View(cvm);
        }
        public ActionResult Delete(string id)
        {
            string connId = User.Identity.GetUserId();
            UnitofWork.ConnectionManager.RemoveConnection(id, connId);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Education education = await db.Educations.FindAsync(id);
            //if (education == null)
            //{
            //    return HttpNotFound();
            //}
            return RedirectToAction("Index");

        }
    }
}