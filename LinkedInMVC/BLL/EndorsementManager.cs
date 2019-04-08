using LinkedInMVC.Models;
using LinkedInMVC.ViewModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class EndorsementManager : Repository<Endorsement , ApplicationDbContext> 
    {
        private readonly ApplicationDbContext context;
        public EndorsementManager(ApplicationDbContext context) : base(context)
        {
            this.context = context;

        }
        public List<EndorsementViewModel> GetSkillsEndorsements(string id, List<SkillViewModel> skills)
        {
          
            List<EndorsementViewModel> EndorsementsVM = new List<EndorsementViewModel>();
            EndorsementViewModel tempObj = new EndorsementViewModel();
            foreach (var skill in skills)
            {
                tempObj = new EndorsementViewModel();
                tempObj.EndorsedByNames = context.Endorsement.Where(u => (u.Fk_EndorsedUserID.Id == id) &&( u.FK_SkillId.Id == skill.Id)).Select(e => e.Fk_EndorsedByUserID.FirstName + " " +  e.Fk_EndorsedByUserID.SecondName).ToList();
                tempObj.Skill = skill;
                tempObj.Id = context.Endorsement.Where(u => (u.Fk_EndorsedUserID.Id == id) && (u.FK_SkillId.Id == skill.Id)).Select(e => e.Id).ToList().FirstOrDefault();
                EndorsementsVM.Add(tempObj);
            }

            return EndorsementsVM;

        }
    }
}