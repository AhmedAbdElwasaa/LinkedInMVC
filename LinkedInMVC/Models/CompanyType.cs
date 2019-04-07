using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
<<<<<<< HEAD
    [Table("Company_Type")]
=======
    [Table("Company Type")]
>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7
    public class CompanyType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
     
        public ICollection<Company> Companies { get; set; }
    }
}