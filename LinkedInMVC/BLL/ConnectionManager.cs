using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
namespace LinkedInMVC.BLL
{
    public class ConnectionManager : Repository<Connection_Request, ApplicationDbContext>
    {
        private readonly ApplicationDbContext context;
        public ConnectionManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;

        }
        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Get<UnitofWork>();
            }
        }
        public void AddFriendRequest(string userId, string connectionId)
        {
            Connection_Request friend = new Connection_Request();
            friend.FK_UserId.Id = userId;
            friend.FK_Connction_UserId.Id = connectionId;
            friend.IsApproved = false;
            context.Connection_Requeset.Add(friend);
            context.SaveChanges();
        }
        public List<ApplicationUser> GetAllFriend(string userId)
        {
            //var x= context.Connection_Requeset.Where(u => u.FK_UserId.Id== userId).Select(e => e).ToList();
            var connlist = context.Connection_Requeset.Where(u => u.IsApproved == true && u.FK_UserId.Id == userId).Select(y => y).ToList();
            List<ApplicationUser> users = new List<ApplicationUser>();
            foreach (var item in connlist)
            {
                List<ApplicationUser> u = UnitofWork.UserManager.Users.Where(e => e.Id == item.FK_Connction_UserId.Id).ToList();
                users.Add(u[0]);
            }
            return users;

        }
        public List<ApplicationUser> GetAllFriendRequest(string userId)
        {

            List<Connection_Request> connlist = context.Connection_Requeset.Where(u => u.IsApproved == false && u.FK_UserId.Id == userId).Select(l => l).ToList();
            List<ApplicationUser> users = new List<ApplicationUser>();
            foreach (var item in connlist)
            {
                List<ApplicationUser> u = UnitofWork.UserManager.Users.Where(e => e.Id == item.FK_Connction_UserId.Id).ToList();
                users.Add(u[0]);
            }
            return users;

        }
        public void AcceptFriendRequest(string userId, string connectionId)
        {
            Connection_Request result = context.Connection_Requeset.SingleOrDefault(u => u.FK_UserId.Id == userId && u.FK_Connction_UserId.Id == connectionId);
            if (result != null)
            {
                result.IsApproved = true;
                context.SaveChanges();

            }
            Connection_Request friend = new Connection_Request();
            friend.FK_UserId.Id = connectionId;
            friend.FK_Connction_UserId.Id = userId;
            friend.IsApproved = true;
            context.Connection_Requeset.Add(friend);
            context.SaveChanges();
        }
        public List<ApplicationUser> GetMetualFriend(string userId)
        {
            List<ApplicationUser> friendsOffriends = new List<ApplicationUser>();
            ConnectionManager con = new ConnectionManager(context);
            List<ApplicationUser> friends = con.GetAllFriend(userId);
            foreach (ApplicationUser item in friends)
            {
                List<ApplicationUser> friendsOffriend = con.GetAllFriend(item.Id);
                foreach (ApplicationUser i in friendsOffriend)
                {
                    if (i.Id != userId)
                    {

                        friendsOffriends.Add(i);
                    }

                }


            }
            return friendsOffriends;

        }

    }
}
