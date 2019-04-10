using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Seniority")]
    public class SeniorityLevel
    {
        [Key]
        public int Id { get; set; }
        public string Level { get; set; }

        public Job Job { get; set; }
        [ForeignKey("Job")]
        public int? JobFK { get; set; }
    }
}