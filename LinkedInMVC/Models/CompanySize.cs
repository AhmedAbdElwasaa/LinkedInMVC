using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Company_Size")]
    public class CompanySize
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }
      
        public ICollection<Company> Companies { get; set; }
    }
}