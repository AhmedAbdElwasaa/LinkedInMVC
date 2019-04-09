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

<<<<<<< HEAD
     
        public Company Company
        {
            get
            ;
            set;
        }
        [Required(ErrorMessage = "must choose company type")]
=======

        public Company Company { get; set; }
>>>>>>> 367e97306dec3a1e4f16b13c701d80a8e38bf59c
        [DisplayName("Company type *")]
        public List<SelectListItem> Types { get; set; }
        [DisplayName("Industry *")]
<<<<<<< HEAD
        public List<SelectListItem> Industries
        {
            get;
            set; 
            
        }
        [Required(ErrorMessage = "must choose company size")]
        [DisplayName("Company size *")]
        public List<SelectListItem> Sizes { get; set; }
        [Required(ErrorMessage ="must check box if you are agree")]
        public bool Selected { get; set; }
        public Industry Industry { get; set; }


=======
        public List<SelectListItem> Industries { get; set; }
        [DisplayName("Company size *")]
        public List<SelectListItem> Sizes { get; set; }
>>>>>>> 367e97306dec3a1e4f16b13c701d80a8e38bf59c
    }
}