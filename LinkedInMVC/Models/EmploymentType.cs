using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Employment_Type")]
    public class EmploymentType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }

        public Job Job { get; set; }
        [ForeignKey("Job")]
        public int? JobFK { get; set; }
    }
}