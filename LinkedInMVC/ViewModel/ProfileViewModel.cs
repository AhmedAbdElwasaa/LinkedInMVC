using LinkedInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.ViewModel
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ProfileImage { get; set; }

        public string ProfileCover { get; set; }

        public string CurrentCopmany { get; set; }
        public string Headline { get; set; }
        public string Country { get; set; }
        public int NumOfConnections { get; set; }


        public List<EducationViewModel> Educations { get; set; }
        public List<ExperienceViewModel> Experiences { get; set; }
    }
}