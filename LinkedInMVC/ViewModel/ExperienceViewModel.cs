using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.ViewModel
{
    public class ExperienceViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Company { get; set; }
        public string Location { get; set; }
        public int FromYear { get; set; }
        public string ToYear { get; set; }
    }
}