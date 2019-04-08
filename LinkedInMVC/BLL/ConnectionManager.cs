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
            ApplicationUser ApplicationUser;
            ApplicationUser = UnitofWork.UserManager.Users
                .Where(e => e.Id == connectionId).FirstOrDefault();
            ApplicationUser ApplicationUser2;
            ApplicationUser2 = UnitofWork.UserManager.Users
                .Where(e => e.Id == userId).FirstOrDefault();
            Connection_Request con = new Connection_Request();
            con.FK_UserId = ApplicationUser;
            con.FK_Connction_UserId = ApplicationUser2;
            con.IsApproved = false;
            context.Connection_Requeset.Add(con);
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
                    if (i.Id != userId && !friends.Contains(i)&& !checkFreindRequest(userId,i.Id) )
                    {

                        friendsOffriends.Add(i);
                    }

                }



            }
            return friendsOffriends;

        }
        public void RemoveConnection(string userId , string connId)
        {
            Connection_Request connecToDelete = context.Connection_Requeset
             .Select(p => p).Where(p => p.FK_UserId.Id == userId && p.FK_Connction_UserId.Id==connId && p.IsApproved==true).FirstOrDefault();
            context.Connection_Requeset.Remove(connecToDelete);
            Connection_Request connecToDelete2 = context.Connection_Requeset
          .Select(p => p).Where(p => p.FK_UserId.Id == connId && p.FK_Connction_UserId.Id == userId && p.IsApproved == true).FirstOrDefault();
            context.Connection_Requeset.Remove(connecToDelete2);
            context.SaveChanges();
        }
        public bool checkFreindRequest(string userId ,string connId)
        {
            bool flag=true;
          Connection_Request connlist = context.Connection_Requeset.Where(u => u.IsApproved == false && u.FK_UserId.Id == userId && u.FK_Connction_UserId.Id==connId).Select(y => y).FirstOrDefault();
            if (connlist == null)
            {
                flag = false;
            }
           
            return flag;
        }
    }
}
