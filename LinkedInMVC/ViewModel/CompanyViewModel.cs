using LinkedInMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedInMVC.ViewModel
{
    public class CompanyViewModel
    {

     
        public Company Company
        {
            get
            ;
            set;
        }
        [Required(ErrorMessage = "must choose company type")]
        [DisplayName("Company type *")]
        public List<SelectListItem> Types { get; set; }
        [Required(ErrorMessage = "must choose company industry")]
        [DisplayName("Industry *")]
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


    }
}