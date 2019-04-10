var edu = null;
var exp = null;
var skill = null;

// Add education


$("#EduBtnSave").click(() => {
    edu = {

        SchoolName: $("#Education_SchoolName").val(),
        Degree: $("#Education_Degree").val(),
        FieldOfStudy: $("#Education_FieldOfStudy").val(),
        Grade: $("#Education_Grade").val()
        //date

    }
   

});


function OnSuccessAddEducation() {

    $(".education-container").append(`<div class="education">
        <div class= "education-data">
        <div class="btn-edit-education" data-toggle="modal" data-target="#AddEducationModal"><i class="fas fa-pen"></i></div>
            <div class="school-img-container">
    <img src="../images/Logo.png" class="school-img">
            </div>
    <div class="education-details">
        <input type="hidden" value="@Model.Id" />
        <h4 class="school-name"> ${edu.SchoolName}</h4>
        <h4 class="Degree">${edu.Degree}</h4>
        <h3 class="study-feild">${edu.FieldOfStudy}</h3>
        <h3 class="Grade">${edu.Grade}</h3>
        <div class="date">
            <h4 class="date-from">@Model.FromYear</h4>
            <span> - </span>
            <h4 class="date-to">@Model.ToYear</h4>
        </div>
    </div>
</div>
    </div >`);
    EducationForm[1].value = "";
    EducationForm[2].value = "";
    EducationForm[3].value = "";
    EducationForm[4].value = "";

}


//////////////////edit education  ///////////////////////////////

$(".btn-edit-education").click(function () {
    let [, EducationModal] = $("#EditEducationModal").children().children().children();
    let EducationForm = EducationModal.children.EditEducationForm;
   
     [, , temp] = $(this).parent().children();
    EductionDetails = temp.children;

    let id = EductionDetails[0].value;
    let schoolName = EductionDetails[1].textContent;
    let degree = EductionDetails[2].textContent;
    let field = EductionDetails[3].textContent;
    let grade = EductionDetails[4].textContent;
    //let startDate=

    EducationForm[1].value = id;
    EducationForm[2].value = schoolName;
    EducationForm[3].value = degree;
    EducationForm[4].value = field;
    EducationForm[5].value = grade;



});


$("#EditEduBtnSave").click(() => {
    let [, EducationModal] = $("#EditEducationModal").children().children().children();
    let EducationForm = EducationModal.children.form1;

    debugger
    edu = {

        SchoolName: EducationForm[2].value,
        Degree: EducationForm[3].value,
        FieldOfStudy: EducationForm[4].value,
        Grade: EducationForm[5].value
        //date

    }
    debugger

});

function OnSuccessEditEducation() {

    debugger

    EductionDetails[1].textContent = edu.SchoolName;
    EductionDetails[2].textContent = edu.Degree;

    EductionDetails[3].textContent = edu.FieldOfStudy;
    EductionDetails[4].textContent = edu.Grade;


}
//////////////////////////Delete Education ////////////////////////////////////

$("#DeleteEduBtn").click(() => {
    let [, EducationModal] = $("#EditEducationModal").children().children().children();
    let EducationForm = EducationModal.children.EditEducationForm;
    let idd =  EducationForm[1].value;

    $.ajax({
        url: `/Educations/Delete/${idd}`,
        type: "Get",
        success: function (response) {
            alert("yayyyyyyyyyy")

        }
    });
});


/////////////////////// Add Experience//////////////////////////////////////////

$("#ExpBtnSave").click(() => {

    exp = {

        Title: $("#Experience_Title").val(),
        Company: $("#Experience_Company").val(),
        Location: $("#Experience_Location").val(),
        //date

    }


});


function OnSuccessAddExperience() {
    debugger
    $(".experience-container").append(`  <div class="experience">
            <div class="experience-data">
                <div class="btn-edit-experience"  data-toggle="modal" data-target="#ExperienceModal"><i class="fas fa-pen"></i></div>
                <div class="company-img-container">
                    <img src="../images/Logo.png" class="company-img">
                </div>
                <div class="experience-details">
                    <h4 class="title"> ${exp.Title}</h4>
                    <h4 class="company-name">${exp.Company}</h4>
                    <h4 class="company-name">${exp.Location}}</h4>
                    <div class="date">
                        <h4 class="date-from">@Model.ToYear</h4>
                        <span> - </span>
                        <h4 class="date-to">@Model.ToYear</h4>
                    </div>
                </div>
            </div>
        </div>`);


}

////////////////////////////////Edit Experience ////////////////////////


$(".btn-edit-experience").click(function () {
    let [, ExperienceModal] = $("#EditExperienceModal").children().children().children();
    let ExperienceForm = ExperienceModal.children.EditExperienceForm;

    
    [, , temp] = $(this).parent().children();
    ExperienceDetails = temp.children;
    
    let id = ExperienceDetails[0].value;
    let title = ExperienceDetails[1].textContent;
    let companyName = ExperienceDetails[2].textContent;
    let companyLocation = ExperienceDetails[3].textContent;
    //let startDate=

    ExperienceForm[1].value = id;
    ExperienceForm[2].value = title;
    ExperienceForm[3].value = companyName;
    ExperienceForm[4].value = companyLocation;



});


$("#ExpEditBtnSave").click(() => {
    let [, ExperienceModal] = $("#EditExperienceModal").children().children().children();
    let ExperienceForm = ExperienceModal.children.EditExperienceForm;
    exp = {

        id: ExperienceForm[1].value,
        Title: ExperienceForm[2].value,
        CompanyName: ExperienceForm[3].value,
        Location: ExperienceForm[4].value
        //date

    }

});

function OnSuccessEditExperience() {
    ExperienceDetails[1].textContent = exp.Title;
    ExperienceDetails[2].textContent = exp.CompanyName;
    ExperienceDetails[3].textContent = exp.Location;


}



/////////////////////Add  skills/////////////////////////////

$("#SkillBtnSave").click(() => {

    skill = {

        Title: $("#Skill_SkillName").val()
        //date

    }
});


function OnSuccessAddSkill() {
    debugger
    $(".skills-container").append(`  <div class="skill">
    <div class="skill-data">
        <button class="plus-icon-container">
            <i class="fas fa-plus"></i>
        </button>
        <div class="skill-name">${skill.Title}</div>
        <input type="hidden" value="${skill.Id}" />
    </div>
</div>
`);


}

////////////////////Edit skills////////////////////////////////////////////

$(".btn-edit-skills").click(function () {
    let [, SkillModal] = $("#EditSkillsModal").children().children().children();
    let SkillForm = SkillModal.children.EditSkillForm;
    debugger
    [, , temp] = $(this).parent().children();
    SkillDetails = temp.children;
  
   
    let Skill = SkillDetails[0].textContent;
    let id = SkillDetails[1].value;
    //let startDate=

    SkillForm[1].value = id;
    SkillForm[2].value = Skill;
    
});


$("#EditSkillBtnSave").click(() => {
    let [, skillModal] = $("#EditSkillsModal").children().children().children();
    let SkillForm = skillModal.children.EditSkillForm;
    skill = {

        id: SkillForm[1].value,
        skillName: SkillForm[2].value,
      
        //date

    }
   
});

function OnSuccessEditSkill() {

    debugger
    SkillDetails[0].textContent = skill.skillName;
   

}
////////////////////////// Endorsement //////////////////////////// AddSkill

$(".Endorse-Btn").click(function () {


    let Data = $(this).parent().children()[2];
    let Endorsements = $(this).parent().parent().children()[1];
    let SpanEndorsement = Endorsements.children;
    let id = Data.children[1].value;
    let temp = window.location.href;
    let EId = temp.split('/')[5];
    debugger
    $.ajax({
        url: `/Endorsements/Create/${id}/${EId}`,
        type: "Get",
        success: function (response) {
            SpanEndorsement.append("hiiiii");
           

        }
    });


});



//function OnSuccessAddEndorsedName() {



//}




////////////////////////// change cover images /////////////////////////











//$("#btnChangeProfile").click(() => {


//    $.ajax({
//        url: `/Profile/Edit`,
//        type: "Get",
//        success: function (response) {
//            alert("yayyyyyyyyyy")

//        }
//    });


//});


//$("#btnChangeCover").click(() => {
//    edu = {

//        SchoolName: $("#Education_SchoolName").val(),
//        Degree: $("#Education_Degree").val(),
//        FieldOfStudy: $("#Education_FieldOfStudy").val(),
//        Grade: $("#Education_Grade").val()
//        //date

//    }


//});