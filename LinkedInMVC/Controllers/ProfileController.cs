using LinkedInMVC.Models;
using LinkedInMVC.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LinkedInMVC.Controllers
{
    public class ProfileController : Controller
    {

        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }
        // GET: Profile
        public ActionResult Index()
        {

            string id = User.Identity.GetUserId();
            ApplicationUser currentUser = UnitofWork.UserManager.FindById(id);
            ProfileViewModel ProfileVM;
            if (User.Identity.IsAuthenticated)
            {
                List<EducationViewModel> userEducations = UnitofWork.UserEducationManager.GetUserEducations(id);
                List<ExperienceViewModel> userExperiences = UnitofWork.UserExperienceManager.GetUserExperiences(id);
                List<SkillViewModel> userSkills = UnitofWork.UserSkillManager.GetUserSkills(id);
                List<EndorsementViewModel> endorsements = UnitofWork.EndorsementManager.GetSkillsEndorsements(id, userSkills);

                

                ProfileVM = new ProfileViewModel
                {
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.SecondName,
                    ProfileImage = currentUser.ProfileImage,
                    ProfileCover = currentUser.ProfileCover,
                    CurrentCopmany = currentUser.CurrentCopmany,
                    Headline = currentUser.Headline,
                    Country = currentUser.Country,
                    NumOfConnections = currentUser.NumOfConnections,
                    Educations = userEducations,
                    Experiences = userExperiences,
                    Skills=userSkills,
                    Endorsements= endorsements
                };
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(ProfileVM);
        }


        public  ActionResult Details(String id)
        {
            //  string id = User.Identity.GetUserId();
            ApplicationUser user = UnitofWork.UserManager.FindById(id);
            ProfileViewModel ProfileVM;
            if (user != null)
            {
                List<EducationViewModel> userEducations = UnitofWork.UserEducationManager.GetUserEducations(id);
                List<ExperienceViewModel> userExperiences = UnitofWork.UserExperienceManager.GetUserExperiences(id);
                List<SkillViewModel> userSkills = UnitofWork.UserSkillManager.GetUserSkills(id);
                List<EndorsementViewModel> endorsements = UnitofWork.EndorsementManager.GetSkillsEndorsements(id, userSkills);

                ProfileVM = new ProfileViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.SecondName,
                    ProfileImage = user.ProfileImage,
                    ProfileCover = user.ProfileCover,
                    CurrentCopmany = user.CurrentCopmany,
                    Headline = user.Headline,
                    Country = user.Country,
                    NumOfConnections = user.NumOfConnections,
                    Educations = userEducations,
                    Experiences = userExperiences,
                    Skills = userSkills,
                    Endorsements = endorsements
                };
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(ProfileVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file)
        {
            //string id = User.Identity.GetUserId();
            //ApplicationUser currentUser = UnitofWork.UserManager.FindById(id);

            //currentUser.FirstName = profile.FirstName;
            //currentUser.SecondName = profile.LastName;
            //currentUser.ProfileImage = profile.ProfileImage;
            //currentUser.ProfileCover = profile.ProfileCover;

            //UnitofWork.UserManager.Update(currentUser);

            return RedirectToAction("Index", "Profile");
        }

    }
}     