using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Education")]
    public class Education
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public string Grade { get; set; }
        public int FromYear { get; set; }
        public string ToYear { get; set; }

        //public Profile Profile { get; set; }
        public virtual ICollection<UserEducation> UserEducation { get; set; }

    }
}