using LinkedInMVC.BLL;
using LinkedInMVC.Models;
using LinkedInMVC.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedInMVC.Controllers
{
    public class LikesController : Controller
    {
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }
        // GET: Likes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddLike(PostViewModel post)
        {
            ApplicationUser ApplicationUser;
            string id = User.Identity.GetUserId();
            ApplicationUser = UnitofWork.UserManager.Users
                .Where(e => e.Id == id).FirstOrDefault();
            if (UnitofWork.LikesManager.GetLikers(post.Id).Any(l => l == ApplicationUser))
            {

                return RemoveLike(ApplicationUser, post.Id);
            }
            Post post_ = UnitofWork.LikesManager.AddLikes(ApplicationUser, post.Id);
            int likesNum = post_.numOfLikes;
            post_.numOfLikes = likesNum;
            LikesViewModel likesViewModel = new LikesViewModel
            {
                num = likesNum,
                likers = UnitofWork.LikesManager.GetLikers(post.Id).ToList()
            };
            //turn Content(likesNum.ToString());
            return PartialView("_LikesPartial", likesViewModel);
        }
        public ActionResult RemoveLike(ApplicationUser ApplicationUser, int postId)
        {

            Post post = UnitofWork.LikesManager.deleteLikes(ApplicationUser, postId);
            int likesNum = post.numOfLikes;
            post.numOfLikes = likesNum;
            LikesViewModel likesViewModel = new LikesViewModel
            {
                num = likesNum,
                likers = UnitofWork.LikesManager.GetLikers(post.Id).ToList()
            };
            return PartialView("_LikesPartial", likesViewModel);
            //return PartialView("_LikesPartial", likesNum);
        }
        public ActionResult GetLikes(int postId)
        {
            List<ApplicationUser> usersLikeIt = UnitofWork.LikesManager.GetLikers(postId);
            return PartialView("_LikesModalPartial", usersLikeIt);
        }
    }
}