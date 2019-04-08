using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Skill")]
    public class Skill
    {
        public int Id { get; set; }

        [Display(Name = "Skill Name")]
        public string SkillName { get; set; }
        public virtual ICollection<UserSkill> UserSkill { get; set; }

    }
}