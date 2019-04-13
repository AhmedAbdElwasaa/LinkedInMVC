using LinkedInMVC.Models;
using LinkedInMVC.ViewModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class UserSkillManager : Repository<UserSkill, ApplicationDbContext>
    {
        private readonly ApplicationDbContext context;
        public UserSkillManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }


        public List<SkillViewModel> GetUserSkills(string id)
        {


            List<int> SkillsIds = context.UserSkills.Where(u => u.UserId.Id == id).Select(e => e.Skill.Id).ToList();
            List<SkillViewModel> Skills = new List<SkillViewModel>();

            foreach (int item in SkillsIds)
            {
                var skill = context.skill
                 .Where(u => u.Id == item).Select(e =>
                 new SkillViewModel
                 {
                     Id = e.Id,
                     SkillName=e.SkillName
                    
                 }).FirstOrDefault();

                Skills.Add(skill);

            }
            return Skills;
        }


        public List<SkillViewModel> GetUserSkills(string id , ApplicationUser userId)
        {


            List<int> SkillsIds = context.UserSkills.Where(u => u.UserId.Id == id).Select(e => e.Skill.Id).ToList();
            List<SkillViewModel> Skills = new List<SkillViewModel>();

            foreach (int item in SkillsIds)
            {
                var skill = context.skill
                 .Where(u => u.Id == item).Select(e =>
                 new SkillViewModel
                 {
                     Id = e.Id,
                     SkillName = e.SkillName

                 }).FirstOrDefault();

                Skills.Add(skill);

            }
            return Skills;
        }


        public bool AddUserSkill(Skill skill, ApplicationUser user)
        {
            UserSkill userSkill = new UserSkill();
            userSkill.UserId = user;
            userSkill.Skill = skill;

            context.UserSkills.Add(userSkill);


            return context.SaveChanges() > 0;
        }
    }
}