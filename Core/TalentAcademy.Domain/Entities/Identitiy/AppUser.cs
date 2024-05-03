using Microsoft.AspNetCore.Identity;
using TalentAcademy.Domain.Enums;

namespace TalentAcademy.Domain.Entities.Identitiy
{
    public class AppUser : IdentityUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
        public Gender Gender { get; set; }
        public DateTime BirthOfDate { get; set; }
        public string? Image { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

    }
}
