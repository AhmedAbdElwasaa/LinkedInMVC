using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Company")]
    public class Company
    {
<<<<<<< HEAD

   
        public Company()
        {
           
                this.UserCompanies = new HashSet<UserCompany>();
              
           
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="name shouldn't be empty")]
        [MinLength(8,ErrorMessage ="Name must be bigger than 8 characters")]
        public string  Name { get; set; }
        [Url(ErrorMessage ="text must be url")]
        [DisplayName("Website")]
        public string  URL { get; set; }
        [Required(ErrorMessage ="Image musn't empty")]
=======
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        [DisplayName("Website")]
        public string  URL { get; set; }
>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7
        public string Logo { get; set; }
        public string Cover { get; set; }
        public string Type { get; set; }
        [Column("Industry")]
        public string CompanyIndustry { get; set; }
        public string Size { get; set; }
<<<<<<< HEAD

        public string Address { get; set; }
        [DisplayName("TagLine")]
        public string Description { get; set; }
        [NotMapped]
        public HttpPostedFileBase LogoFileName { get; set; }
        [NotMapped]
        public HttpPostedFileBase CoverFileName { get; set; }
        public ICollection<UserCompany> UserCompanies { get; set; }
        public CompanySize CompanySize { get; set; }
        public CompanyType CompanyType { get; set; }
    
=======
        public string Address { get; set; }
        [DisplayName("TagLine")]
        public string Description { get; set; }
        public ICollection<UserCompany> UserCompanies { get; set; }
        
        public CompanySize CompanySize { get; set; }
      
        public CompanyType CompanyType { get; set; }
       
>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7
        public Industry Industry { get; set; }

    }
}