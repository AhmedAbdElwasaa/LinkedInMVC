using System;
using LinkedInMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }

        //Creator of the post 
        public virtual ApplicationUser ApplicationUser { get; set; }

        //Refernce to the original post 
        public Post Post_Shared { get; set; }

        public string postText { get; set; }
        public DateTime Date { get; set; }

        public int numOfLikes { get; set; }

        public int numOfComments { get; set; }

        public int numOfShares { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public bool liked { get; set; }
        public LikesViewModel LikesViewModel { get; set; }
    }
}