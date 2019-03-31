using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int Id { get; set; }

        //Creator of the post 
        public ApplicationUser ApplicationUser { get; set; }

        //Refernce to the original post 
        public Post Post_Shared { get; set; }

        public string postText { get; set; }
        public DateTime Date  { get; set; }

        [DefaultValue(0)]
        public int numOfLikes { get; set; }

        [DefaultValue(0)]
        public int numOfComments { get; set; }

        [DefaultValue(0)]
        public int numOfShares { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}