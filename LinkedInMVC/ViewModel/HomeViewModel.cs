﻿using LinkedInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.ViewModel
{
    public class HomeViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public PostViewModel[] PostViewModels { get; set; }
        public int count = 4;
    }
}