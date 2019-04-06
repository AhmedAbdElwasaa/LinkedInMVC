using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class LikesManager : Repository<Like, ApplicationDbContext>
    {
        private ApplicationDbContext context;
        public LikesManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
       
        public Post  AddLikes(ApplicationUser user, int postId)
        {
            //Add like with user id in Likes table
            Like userlike = new Like();
            userlike.ApplicationUser = user;
            userlike.Fk_PostId = postId;
            context.Likes.Add(userlike);
            context.SaveChanges();

            //Update number of likes in post table
            Post post = context.Posts.FirstOrDefault(p => p.Id == postId);
            post.numOfLikes = post.numOfLikes + 1;
            PostsManager postsManager = new PostsManager(context);
            postsManager.Update(post);
            return context.Posts.FirstOrDefault(p => p.Id == postId);
        }
        public Post deleteLikes(string userId, int postId)
        {
            //Delete like with user id in Likes table
            Like userlike = new Like();
            userlike.ApplicationUser.Id = userId;
            userlike.Fk_PostId = postId;
            context.Likes.Remove(userlike);
            context.SaveChanges();

            //Update number of likes in post table
            Post post = context.Posts.FirstOrDefault(p => p.Id == postId);
            post.numOfLikes = post.numOfLikes - 1;
            PostsManager postsManager = new PostsManager(context);
            postsManager.Update(post);
            return context.Posts.FirstOrDefault(p => p.Id == postId);
        }

    }
}