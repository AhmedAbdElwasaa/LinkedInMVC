<<<<<<< HEAD
﻿
using System;
=======
﻿using System;
>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    [Table("User_Company")]
    public class UserCompany
    {
<<<<<<< HEAD
        public UserCompany()
        {
            this.Company = new Company();
            this.ApplicationUser = new ApplicationUser();
        }
=======
>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7
        public int Id { get; set; }
        public Company Company { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}