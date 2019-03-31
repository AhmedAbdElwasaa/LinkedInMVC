using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("UserEducation")]
    public class UserEducation
    {
        public int? Id { get; set; }
        public ApplicationUser UserId { get; set; }
        public Education Education { get; set; }

    }
}