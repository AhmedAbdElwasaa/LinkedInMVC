using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{

    [Table("Company_Type")]

    public class CompanyType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
     
        public ICollection<Company> Companies { get; set; }
    }
}