using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("UserExperience")]
    public class UserExperience
    {
        public int? Id { get; set; }
        public ApplicationUser UserId { get; set; }
        public Experience Experience { get; set; }
    }
}