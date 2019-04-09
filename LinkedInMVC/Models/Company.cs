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
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        [DisplayName("Website")]
        public string  URL { get; set; }
        public string Logo { get; set; }
        public string Cover { get; set; }
        public string Address { get; set; }
        [DisplayName("TagLine")]
        public string Description { get; set; }
<<<<<<< HEAD
        [NotMapped]
        [Required(ErrorMessage = "Image musn't empty")]
        public HttpPostedFileBase LogoFileName { get; set; }
        [NotMapped]
        public HttpPostedFileBase CoverFileName { get; set; }
=======
>>>>>>> 367e97306dec3a1e4f16b13c701d80a8e38bf59c
        public ICollection<UserCompany> UserCompanies { get; set; }
        
        public CompanySize CompanySize { get; set; }
      
        public CompanyType CompanyType { get; set; }
       
        public Industry Industry { get; set; }
<<<<<<< HEAD
        [ForeignKey("Industry")]
        public int? Industry_FKId { get; set; }
        public ICollection<Job> JobFK { get; set; }
=======
>>>>>>> 367e97306dec3a1e4f16b13c701d80a8e38bf59c

    }
}