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
        public  void AddLikes(string userId, int postId)
        {
            Like userlike = new Like();
            userlike.ApplicationUser.Id = userId;
            userlike.Fk_PostId = postId;
            context.Likes.Add(userlike);
            context.SaveChanges();
        }
        public  void deleteLikes(string userId, int postId)
        {
            Like userlike = new Like();
            userlike.ApplicationUser.Id = userId;
            userlike.Fk_PostId = postId;
            context.Likes.Remove(userlike);
            context.SaveChanges();
        }

    }
}