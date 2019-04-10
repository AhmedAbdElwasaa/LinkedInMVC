using LinkedInMVC.Models;
using LinkedInMVC.ViewModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{

    public class UserExperienceManager :Repository<UserExperience, ApplicationDbContext>
    {
        private readonly ApplicationDbContext context;
        public UserExperienceManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public List<ExperienceViewModel> GetUserExperiences(string id)
        {
        
            List<int> ExperiencesId = context.UserExperiences.Where(u => u.UserId.Id == id).Select(e => e.Experience.Id).ToList();
            List<ExperienceViewModel> Experiences = new List<ExperienceViewModel>();
            foreach (int item in ExperiencesId)
            {
                var experience = context.Experience.Where(u => u.Id == item).Select(e =>
                 new ExperienceViewModel
                 {
                     Id = e.Id,
                     Company = e.Company,
                     Title = e.Title,
                     Location = e.Location,
                     FromYear = e.FromYear,
                     ToYear = e.ToYear,    

                 }).FirstOrDefault();

                Experiences.Add(experience);

            }
            return Experiences;
        }


        public bool AddUserExperience(Experience experience, ApplicationUser user)
        {
            UserExperience userExperience = new UserExperience();
            userExperience.UserId = user;
            userExperience.Experience = experience;

            context.UserExperiences.Add(userExperience);


            return context.SaveChanges() > 0;
        }
    }
}