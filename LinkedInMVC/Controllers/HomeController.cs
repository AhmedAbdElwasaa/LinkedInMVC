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
    public class HomeController : Controller
    {
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }
        public ActionResult Index()
        {
            bool liked = false;
            ApplicationUser ApplicationUser;
            string id = User.Identity.GetUserId();
            ApplicationUser = UnitofWork.UserManager.Users
                .Where(e => e.Id == id).FirstOrDefault();
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.ApplicationUser = ApplicationUser;
            List<PostViewModel> postViewModels = new List<PostViewModel>();
            var allPosts = UnitofWork.PostsManager.GetAll().ToArray();
            LikesViewModel LikesViewModel;
            foreach (Post post in allPosts)
            {
                LikesViewModel = new LikesViewModel { likers = UnitofWork.LikesManager.GetLikers(post.Id), num = post.numOfLikes };
                if (UnitofWork.LikesManager.GetLikers(post.Id).Any(l =>l.Id == id))
                {
                    liked = true;
                }
                postViewModels.Add(new PostViewModel
                {
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
            homeViewModel.PostViewModels = postViewModels.ToArray();
           
            return View(homeViewModel);
        }
        public ActionResult GetLatest()
        {
            return PartialView("");
        }
        public ActionResult GetTop()
        {
            return PartialView("");
        }
        

        public ActionResult SearchPeople(string searchedText)
        {
            List<SearchResultViewModel> results = new List<SearchResultViewModel>();
            foreach (var item in UnitofWork.HomeManager.SearchPeople(searchedText))
            {
                results.Add(new SearchResultViewModel
                {
                    applicationUser = item,
                    first = false,
                    second = false
                });
            }
            return View("SearchResults", results);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}