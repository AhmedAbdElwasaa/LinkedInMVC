using LinkedInMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedInMVC.ViewModel
{
    public class CompanyViewModel
    {


        public Company Company { get; set; }
        [DisplayName("Company type *")]
        public List<SelectListItem> Types { get; set; }
        [DisplayName("Industry *")]
        public List<SelectListItem> Industries { get; set; }
        [DisplayName("Company size *")]
        public List<SelectListItem> Sizes { get; set; }
        
    }
}