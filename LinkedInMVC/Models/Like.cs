using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Like")]
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Post Post { get; set; }

        [ForeignKey("Post")]
        public int Fk_PostId { get; set; }
    }
}