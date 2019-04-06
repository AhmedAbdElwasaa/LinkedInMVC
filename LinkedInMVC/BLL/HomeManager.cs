using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class HomeManager : Repository<ApplicationUser, ApplicationDbContext>
    {
        private ApplicationDbContext context;
        public HomeManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        private List<ApplicationUser> SearchPeopleFirst(string searched)
        {
            return context.Users.Where(u => u.FirstName.Contains(searched)).ToList();
        }
        private List<ApplicationUser> SearchPeopleSecond(string searched)
        {
            return context.Users.Where(u => u.SecondName.Contains(searched)).ToList();
        }
        public List<ApplicationUser> SearchPeople(string searched)
        {
            List<ApplicationUser> ls1 = SearchPeopleFirst(searched);
            List<ApplicationUser> ls2 = SearchPeopleSecond(searched);
            foreach(var user in ls2)
            {
                if(!ls1.Any(e=>e.Id == user.Id))
                {
                    ls1.Add(user);
                }
                
            }
            return ls1;
        }
    }
}