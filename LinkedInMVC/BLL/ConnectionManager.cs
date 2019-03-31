using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class ConnectionManager : Repository<Connection_Request, ApplicationDbContext>
    {


        private ApplicationDbContext context;
        public ConnectionManager(ApplicationDbContext context) : base(context)
        {
            context = this.context;

        }
        public void AddFriendRequest(ApplicationUser userId, ApplicationUser connectionId)
        {
            Connection_Request friend = new Connection_Request();
            friend.FK_UserId = userId;
            friend.FK_Connction_UserId = connectionId;
            friend.IsApproved = false;
            context.Connection_Requeset.Add(friend);
            context.SaveChanges();

        }
    }
}
