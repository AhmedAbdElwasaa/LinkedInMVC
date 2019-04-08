using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Endorsement")]
    public class Endorsement
    {
        public int Id { get; set; }
        public ApplicationUser Fk_EndorsedUserID { get; set; }

        public ApplicationUser Fk_EndorsedByUserID { get; set; }

        public Skill FK_SkillId { get; set; }


    }
}