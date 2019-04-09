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
    public class PostsController : Controller
    {
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }
        // GET: Posts
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //Submit the post to the server
        public ActionResult AddPost(Post post)
        {
            ApplicationUser ApplicationUser;
            string id = User.Identity.GetUserId();
            ApplicationUser = UnitofWork.UserManager.Users
                .Where(e => e.Id == id).FirstOrDefault();
            post.ApplicationUser = ApplicationUser;
            post.Date = DateTime.Now;
            UnitofWork.PostsManager.Add(post);
            bool liked = false;
            List<PostViewModel> postViewModels = new List<PostViewModel>();
            var allPosts = UnitofWork.PostsManager.GetAll().ToArray();
            LikesViewModel LikesViewModel;
            foreach (Post post_ in allPosts)
            {
                LikesViewModel = new LikesViewModel { likers = UnitofWork.LikesManager.GetLikers(post_.Id), num = post_.numOfLikes };
                if (UnitofWork.LikesManager.GetLikers(post_.Id).Any(l => l.Id == id))
                {
                    liked = true;
                }
                postViewModels.Add(new PostViewModel
                {
                    ApplicationUser = post_.ApplicationUser,
                    Comments = post_.Comments,
                    Date = post_.Date,
                    Id = post_.Id,
                    liked = liked,
                    Likes = post_.Likes
                ,
                    numOfComments = post_.numOfComments,
                    numOfLikes = post_.numOfLikes,
                    numOfShares = post_.numOfShares
                ,
                    postText = post_.postText,
                    Post_Shared = post_.Post_Shared,
                    LikesViewModel = LikesViewModel
                });
            }
            return PartialView("_PostsPartial", postViewModels.ToArray());
        }
    }
}