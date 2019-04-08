using LinkedInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.ViewModel
{
    public class EndorsementViewModel
    {
        public int Id { get; set; }

        public SkillViewModel Skill { get; set; }
        public List<string> EndorsedByNames { get; set; }
    }
}