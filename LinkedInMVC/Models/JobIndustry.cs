using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Job_Industry")]
    public class JobIndustry
    {
        public int Id { get; set; }
        public Industry IndustryFk { get; set; }
        public Job JobFk { get; set; }
    }
}