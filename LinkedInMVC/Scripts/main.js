var edu = null;
var exp = null;
var skill = null;
var [, EducationModal] = $("#EducationModal").children().children().children();
var EducationForm = EducationModal.children.form0;
//education
$(".btn-edit-education").click(function () {

    let [, , temp] = $(this).parent().children();
    let EductionDetails = temp.children;
    let schoolName = EductionDetails[1].textContent;
    let degree = EductionDetails[2].textContent;
    let field = EductionDetails[3].textContent;
    let grade = EductionDetails[4].textContent;
    //let startDate=
    debugger;
});

$("#EduBtnSave").click(() => {
    edu = {

        SchoolName: $("#Education_SchoolName").val(),
        Degree: $("#Education_Degree").val(),
        FieldOfStudy: $("#Education_FieldOfStudy").val(),
        Grade: $("#Education_Grade").val()
        //date

    }
    $('#EducationModal').modal('hide');

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


}


//$(".btn-edit-education").click(() => {


//    console.log($(this))

//    debugger
//});


//Experience

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

// skills

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
        <input type="hidden" value="@Model.Id" />
    </div>
</div>
`);


}