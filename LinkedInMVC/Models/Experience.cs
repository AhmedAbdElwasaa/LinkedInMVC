using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name ="Start Year")]
        public int FromYear { get; set; }

        [Display(Name="End Year")]
        public string ToYear { get; set; }
        public virtual ICollection<UserExperience> UserExperience { get; set; }

    }
}