using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Job")]
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public DateTime JobDate { get; set; }
        public string JobFunction { get; set; }
        public string JobDescription { get; set; }

        public Industry Industry { get; set; }
        public int? IndustryFK { get; set; }
        public ICollection<JobIndustry> JobIndustryFK { get; set; }

        public Company Company { get; set; }
        [ForeignKey("Company")]
        public int? CompanyFK { get; set; }
        public ICollection<SeniorityLevel> SeniorityLevelsFK { get; set; }
        public ICollection<EmploymentType> EmploymentTypeFK { get; set; }
    }

}