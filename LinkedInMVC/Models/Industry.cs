using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Industry")]
    public class Industry
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<JobIndustry> JobIndustryFk { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}