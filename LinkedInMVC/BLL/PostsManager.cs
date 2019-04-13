using LinkedInMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class PostsManager : Repository<Post, ApplicationDbContext>
    {
        private ApplicationDbContext context;
        public PostsManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Get<UnitofWork>();
            }
        }
        public  List<Post> GetAllByDate(string userId,int count)
        {
            var friendsPosts = GetAllPosts(userId);
            var Posts = friendsPosts
                .OrderByDescending(p => p.Date).ToList();
            List<Post> topPosts = new List<Post>();
            for (int i = 0; count < Posts.ToArray().Length && i <4; ++count)
            {
                topPosts.Add(Posts[count]);
                ++i;
            }
            count += 4;
            return topPosts;
        }
        public List<Post> GetAllByTop(string userId, int count)
        {
            var friendsPosts = GetAllPosts(userId);
            var Posts = friendsPosts
                .OrderByDescending(p => p.numOfComments).ToList();
              List<Post> topPosts = new List<Post>();
            for(int i = 0; count < Posts.ToArray().Length&& i<4; ++count)
            {
                topPosts.Add(Posts[count]);++i;
            }
            count += 4;
            return topPosts;
        }
        public List<Post> GetAllPosts(string userId)
        {
            /***
             * Get Connections of the user who he has access to 
             * view his posts
             * */
            List<string> cons = context
                .Connection_Requeset.Where(c => c.FK_UserId.Id == userId)
                .Where(c => c.IsApproved == true)
                .Select(c => c.FK_Connction_UserId.Id).ToList();
            /***
             * Get the posts of people in cons
             * */
            var friendsPosts = context.Posts
               .Where(p => cons.Any(c => c == p.ApplicationUser.Id)).ToList();
            var myPosts = context.Posts
                .Where(p => p.ApplicationUser.Id == userId).ToList();
            foreach (Post post in myPosts)
            {
                friendsPosts.Add(post);
            }
            return friendsPosts;
        }
        public void deletePost(int postId)
        {
            Post postToDelete = context.Posts
                .Select(p => p).Where(p => p.Id == postId).FirstOrDefault();
            context.Posts.Remove(postToDelete);
            context.SaveChanges();
        }

        /***
         * Load all the posts for the profile page
         * */
        public List<Post> GetAllByUserId(string userId)
        {
            return context.Posts
                .Where(p => p.ApplicationUser.Id == userId).ToList();
        }
        public Post GetByPostId(int postId)
        {
            return (Post)context.Posts
                .Where(e => e.Id == postId);
        }
    }
}