using TalentAcademy.MVC.Enums;

namespace TalentAcademy.MVC.Areas.Admin.Models.Student
{
    public class StudentCreateModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IFormFile Image { get; set; } = null!;
    }
}
