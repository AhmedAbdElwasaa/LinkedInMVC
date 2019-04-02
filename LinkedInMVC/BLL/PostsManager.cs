using LinkedInMVC.Models;
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

        //public static List<Post> GetAllByDate(string userId)
        //{
        //    List<string> cons = context.Connection_Requeset.Where(c => c.FK_UserId.Id == userId)
        //        .Where(c => c.IsApproved == true)
        //        .Select(c => c.FK_Connction_UserId.Id).ToList();
        //    return context.Posts
        //        .Where(p => cons.Any(c => c == p.ApplicationUser.Id))
        //        .OrderBy(p => p.Date).ToList();
        //}
        public List<Post> GetAllByTop(string userId)
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
            return context.Posts
                .Where(p => cons.Any(c => c == p.ApplicationUser.Id))
                .OrderBy(p => p.numOfComments).ToList();
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