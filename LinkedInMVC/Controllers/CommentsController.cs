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
    public class CommentsController : Controller
    {
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }
        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddComment(string CommentText, Post post)
        {
            post.Date = DateTime.Now;
            ApplicationUser ApplicationUser;
            string id = User.Identity.GetUserId();
            ApplicationUser = UnitofWork.UserManager.Users
                .Where(e => e.Id == id).FirstOrDefault();
            Comment comment = new Comment();
            comment.ApplicationUser = ApplicationUser;
            comment.CommentText = CommentText;
            comment.Fk_PostId = post.Id;
            UnitofWork.CommentsManager.AddComment(comment);
            var comments = UnitofWork.CommentsManager.GetCommentByPostId(post.Id).ToArray();
            return PartialView("_CommentsPartial", comments);
        }
    }
}