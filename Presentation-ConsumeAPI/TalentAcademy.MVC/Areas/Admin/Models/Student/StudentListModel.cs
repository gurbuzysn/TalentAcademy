using TalentAcademy.MVC.Enums;

namespace TalentAcademy.MVC.Areas.Admin.Models.Student
{
    public class StudentListModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ImageUri { get; set; }
    }
}
