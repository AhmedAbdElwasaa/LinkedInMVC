using LinkedInMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedInMVC.ViewModel
{
    public class CompanyViewModel
    {


        public Company Company { get; set; }
<<<<<<< HEAD
        [Required(ErrorMessage = "must choose company type")]
        [DisplayName("Company type *")]
        public List<SelectListItem> Types { get; set; }
        [Required(ErrorMessage = "must choose company industry")]
        [DisplayName("Industry *")]
        public List<SelectListItem> Industries { get; set; }
        [Required(ErrorMessage = "must choose company size")]
        [DisplayName("Company size *")]
        public List<SelectListItem> Sizes { get; set; }
        [Required(ErrorMessage ="must check box if you are agree")]
        public bool Selected { get; set; }

=======
        [DisplayName("Company type *")]
        public List<SelectListItem> Types { get; set; }
        [DisplayName("Industry *")]
        public List<SelectListItem> Industries { get; set; }
        [DisplayName("Company size *")]
        public List<SelectListItem> Sizes { get; set; }
>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7
    }
}