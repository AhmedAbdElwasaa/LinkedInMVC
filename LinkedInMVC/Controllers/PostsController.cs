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
            var allPosts = UnitofWork.PostsManager.GetAllByDate(id,0).ToArray();
            LikesViewModel LikesViewModel;
            foreach (Post post_ in allPosts)
            {
                LikesViewModel = new LikesViewModel {
                    likers = UnitofWork.LikesManager.GetLikers(post_.Id)
                    , num = post_.numOfLikes, PostId=post.Id };
                if (UnitofWork.LikesManager.GetLikers(post_.Id).Any(l => l.Id == id))
                {
                    liked = true;
                }
                postViewModels.Add(new PostViewModel
                {
                    CurrentUser = ApplicationUser,
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
        [HttpPost]
        public ActionResult GetSortedPosts(int? x, int count)
        {
            bool liked = false;
            ApplicationUser ApplicationUser;
            string id = User.Identity.GetUserId();
            ApplicationUser = UnitofWork.UserManager.Users
                .Where(e => e.Id == id).FirstOrDefault();
            Post[] LatestPosts;
            Post[] topPosts;
            List<PostViewModel> postViewModels = new List<PostViewModel>();
            if (x == null || x == 0)
            {
                LatestPosts = GetLatest(id,count);
                LikesViewModel LikesViewModel;

                foreach (Post post in LatestPosts)
                {
                    liked = false;
                    var likes = UnitofWork.LikesManager.GetLikers(post.Id);
                    LikesViewModel = new LikesViewModel { likers = likes, num = post.numOfLikes
                    , PostId = post.Id
                    };
                    if (LikesViewModel != null && likes != null && likes.Any(l => l.Id == id))
                    {
                        liked = true;
                    }
                    postViewModels.Add(new PostViewModel
                    {
                        CurrentUser = ApplicationUser,
                        ApplicationUser = post.ApplicationUser,
                        Comments = post.Comments,
                        Date = post.Date,
                        Id = post.Id,
                        liked = liked,
                        Likes = post.Likes
                    ,
                        numOfComments = post.numOfComments,
                        numOfLikes = post.numOfLikes,
                        numOfShares = post.numOfShares
                    ,
                        postText = post.postText,
                        Post_Shared = post.Post_Shared,
                        LikesViewModel = LikesViewModel
                    });
                }
            }
            else
            {
                topPosts = GetTop(id,count);
                LikesViewModel LikesViewModel;

                foreach (Post post in topPosts)
                {
                    liked = false;
                    var likes = UnitofWork.LikesManager.GetLikers(post.Id);
                    LikesViewModel = new LikesViewModel { likers = likes, num = post.numOfLikes, PostId = post.Id };
                    if (LikesViewModel != null && likes != null && likes.Any(l => l.Id == id))
                    {
                        liked = true;
                    }
                    postViewModels.Add(new PostViewModel
                    {
                        CurrentUser = ApplicationUser,
                        ApplicationUser = post.ApplicationUser,
                        Comments = post.Comments,
                        Date = post.Date,
                        Id = post.Id,
                        liked = liked,
                        Likes = post.Likes
                    ,
                        numOfComments = post.numOfComments,
                        numOfLikes = post.numOfLikes,
                        numOfShares = post.numOfShares
                    ,
                        postText = post.postText,
                        Post_Shared = post.Post_Shared,
                        LikesViewModel = LikesViewModel
                    });
                }
            }

            return PartialView("_PostsPartial", postViewModels.ToArray());
        }
        public Post[] GetTop(string id, int count)
        {
            return UnitofWork.PostsManager.GetAllByTop(id, count).ToArray();
        }
        public Post[] GetLatest(string id, int count)
        {
            return UnitofWork.PostsManager.GetAllByDate(id, count).ToArray();
        }
    }
}