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
            ApplicationUser ApplicationUser;
            string id = User.Identity.GetUserId();
            ApplicationUser = UnitofWork.UserManager.Users
                .Where(e => e.Id == id).FirstOrDefault();
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.ApplicationUser = ApplicationUser;
            homeViewModel.posts = UnitofWork.PostsManager.GetAll().ToArray();
            return View(homeViewModel);
        }
        public ActionResult t()
        {
            ApplicationUser ApplicationUser;
            string id = User.Identity.GetUserId();
            ApplicationUser = UnitofWork.UserManager.Users
                .Where(e => e.Id == id).FirstOrDefault();
            Post post = UnitofWork.PostsManager.GetById(2006);
            post = UnitofWork.LikesManager.AddLikes(ApplicationUser, 2006);
            int likesNum = post.numOfLikes;
            post.numOfLikes = likesNum;
            return Content(likesNum.ToString());
        }

        public ActionResult AddLike(Post post)
        {
            ApplicationUser ApplicationUser;
            string id = User.Identity.GetUserId();
            ApplicationUser = UnitofWork.UserManager.Users
                .Where(e => e.Id == id).FirstOrDefault();
            post = UnitofWork.LikesManager.AddLikes(ApplicationUser, post.Id);
            int likesNum = post.numOfLikes;
            post.numOfLikes = likesNum;
            return Content(likesNum.ToString());
            //return PartialView("_LikesPartial", likesNum);
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
            return RedirectToAction("Index");
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