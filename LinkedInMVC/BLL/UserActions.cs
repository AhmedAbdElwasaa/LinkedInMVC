using LinkedInMVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace LinkedInMVC.BLL
{
    public class UserActions : Repository<IdentityUserLogin, ApplicationDbContext>
    {
        public UserActions(ApplicationDbContext context) : base(context)
        {
        }

        //public  void uploadImages(Guid userId, string filePath)
        //{
        //    User_Details ud = new User_Details();
        //    ud.Id = userId;
        //    ud.Image = filePath;
        //    AppManager.linkedInContext.User_Details.Add(ud);
            
        //}

        //public  string uploadProfilePicture(int userId)
        //{
        //    string path = "";
        //    return path;
        //}
        //public  User_Details Login()
        //{
        //    //var userName = Membership.GetUser().UserName;
        //    //if(.User_Details.Any(u=>u.Id == ))
        //    //return ud;
        //}
        //public  User_Details Register()
        //{
        //    var user = Membership.GetUser();
        //    Guid userId = (Guid)user.ProviderUserKey;
        //    User_Details ud = new User_Details();
        //    ud.Id = userId;
        //    return ud;
        //}
        //public List<User_Details> SearchForPeople(string searchedFor)
        //{
        //    AppManager app = new AppManager();
        //    return app.userDetails.GetAll().Where(e => e.Frist_Name == searchedFor
        //    || e.Second_Name == searchedFor || string.Format(e.Frist_Name, e.Second_Name
        //    ) == searchedFor).ToList();
        //}
        //public List<User_Details> Search(string searchedFor)
        //{
        //    return
        //}
        //public List<User_Details> Search(string searchedFor)
        //{
        //    return
        //}
    }
}
