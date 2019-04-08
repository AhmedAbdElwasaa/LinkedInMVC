using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.ViewModel
{
    public class NetworkViewModel
    {
        public List<ConnectionViewModel> MetualFriend { get; set; }
        public List<ConnectionViewModel> FriendRequest { get; set; }
    }
}