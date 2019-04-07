var edu = null;
$("#EduBtnSave").click(() => {

    edu = {

        SchoolName: $("#Education_SchoolName").val(),
        Degree: $("#Education_Degree").val(),
        FieldOfStudy: $("#Education_FieldOfStudy").val(),
        Grade: $("#Education_Grade").val()

    }


    console.log(edu);

});


function OnSuccessAddEducation() {
    debugger
  
    console.log(edu);
    
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

  
 $('#EducationModal').modal('hide');
    
} 


$(".btn-edit-education").click(() => {
    debugger
    var $this = $(this);
    console.log($this.parent())


});