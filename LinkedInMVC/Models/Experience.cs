using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Experience")]
    public class Experience
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Company { get; set; }
        public string Location { get; set; }
<<<<<<< HEAD
        public int FromYear { get; set; }
        public string ToYear { get; set; }

=======

        [Display(Name ="Start Year")]
        public int FromYear { get; set; }

        [Display(Name="End Year")]
        public string ToYear { get; set; }
>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7
        public virtual ICollection<UserExperience> UserExperience { get; set; }

    }
}