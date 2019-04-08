using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("UserSkill")]
    public class UserSkill
    {
        public int? Id { get; set; }
        public ApplicationUser UserId { get; set; }
        public Skill Skill { get; set; }
    }
}