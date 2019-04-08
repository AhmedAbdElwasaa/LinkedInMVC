using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("User_Company")]
    public class UserCompany
    {

        public UserCompany()
        {
            this.Company = new Company();
            this.ApplicationUser = new ApplicationUser();
        }

        public int Id { get; set; }
        public Company Company { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}