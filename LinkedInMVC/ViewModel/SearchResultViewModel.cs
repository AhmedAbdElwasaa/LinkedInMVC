using LinkedInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.ViewModel
{
    public class SearchResultViewModel
    {
        public ApplicationUser applicationUser { get; set; }
        public bool first { get; set; }
        public bool second { get; set; }
    }
}