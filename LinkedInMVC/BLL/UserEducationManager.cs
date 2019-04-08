using LinkedInMVC.Models;
using LinkedInMVC.ViewModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class UserEducationManager : Repository<UserEducation, ApplicationDbContext>
    {
        private readonly ApplicationDbContext context;
        public UserEducationManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public List<EducationViewModel> GetUserEducations(string id)
        {



           // var EducationIdsss = context.UserEducation.Where(u => u.UserId.Id == id).Select(e => e).ToList();

            List<int> EducationIds =  context.UserEducation.Where(u => u.UserId.Id == id).Select(e => e.Education.Id).ToList();
            List<EducationViewModel> Educations = new List<EducationViewModel>();
//            foreach (int item in EducationIds)
//            {
//               var  education= context.Education
//                .Where(u => u.Id == item).Select(e =>
//<<<<<<< HEAD
//                new EducationViewModel { SchoolName = e.SchoolName ,Degree =e.Degree , FieldOfStudy=e.FieldOfStudy ,
//=======
//                new EducationViewModel { Id=e.Id,  SchoolName = e.SchoolName ,Degree =e.Degree , FieldOfStudy=e.FieldOfStudy ,
//>>>>>>> 29bc76c60a8eaeec1aac09f1b2670c43143ba2d7

//                    FromYear =e.FromYear ,ToYear =e.ToYear ,Grade =e.Grade }).FirstOrDefault();

//                Educations.Add(education);

//            }
            return Educations;
        }


        public bool AddUserEducation(Education education, ApplicationUser user)
        {
            UserEducation userEducation = new UserEducation();
            userEducation.UserId = user;
            userEducation.Education = education;

            context.UserEducation.Add(userEducation);


            return context.SaveChanges() > 0;
        }
    }

}