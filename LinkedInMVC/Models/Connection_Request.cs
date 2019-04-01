using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("Connection_Request")]

    public class Connection_Request
    {
        public bool IsApproved { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        public virtual ApplicationUser FK_UserId { get; set; }
        public virtual ApplicationUser FK_Connction_UserId { get; set; }
    }
}