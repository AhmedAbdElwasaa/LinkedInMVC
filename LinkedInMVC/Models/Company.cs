using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Company")]
    public class Company
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string  URL { get; set; }
        public string Logo { get; set; }
        public string Cover { get; set; }
        public string Type { get; set; }
        public string Industry { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<UserCompany> UserCompanies { get; set; }

    }
}