using LinkedInMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.ViewModel
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ProfileImage { get; set; }

        public string ProfileCover { get; set; }

        public string CurrentCopmany { get; set; }
        public string Headline { get; set; }
        public string Country { get; set; }
        public int NumOfConnections { get; set; }

       // public Education Education { get; set; }

        private Education education;

        public Education Education
        {
            get
            {
                if(education==null)
                {

                    education = new Education();
                
                }
                return education;
            }
            set { education = value; }
        }


        private Experience experience;

<<<<<<< HEAD

        private Experience experience;

=======
>>>>>>> 367e97306dec3a1e4f16b13c701d80a8e38bf59c
        public Experience Experience
        {
            get
            {
                if (experience == null)
                {

                    experience = new Experience();

                }
                return experience;
            }
            set { experience = value; }
        }


        private Skill skill;
        public Skill Skill
        {
            get
            {
                if (skill == null)
                {

                    skill = new Skill();

                }
                return skill;
            }
            set { skill = value; }
        }

<<<<<<< HEAD
=======

        private Endorsement endorsement;
        public Endorsement Endorsement
        {
            get
            {
                if (endorsement == null)
                {

                    endorsement = new Endorsement();

                }
                return endorsement;
            }
            set { endorsement = value; }
        }

>>>>>>> 367e97306dec3a1e4f16b13c701d80a8e38bf59c
        public List<EducationViewModel> Educations { get; set; }
        public List<ExperienceViewModel> Experiences { get; set; }

        public List<SkillViewModel> Skills { get; set; }

        public List<EndorsementViewModel> Endorsements { get; set; }

    }
}