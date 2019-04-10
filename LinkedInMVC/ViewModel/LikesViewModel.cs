using LinkedInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.ViewModel
{
    public class LikesViewModel
    {
        public int num { get; set; }
        public List<ApplicationUser> likers { get; set; }
    }
}