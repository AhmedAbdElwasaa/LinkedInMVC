using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Education")]
    public class Education
    {
        public int Id { get; set; }

        [Display(Name = "School Name")]
        public string SchoolName { get; set; }
        public string Degree { get; set; }

        [Display(Name = "Field of study")]
        public string FieldOfStudy { get; set; }
        public string Grade { get; set; }
        [Display(Name = "From Year")]

        public int FromYear { get; set; }
        [Display(Name = "To Year")]
        public string ToYear { get; set; }

        //public Profile Profile { get; set; }
        public virtual ICollection<UserEducation> UserEducation { get; set; }

    }
}