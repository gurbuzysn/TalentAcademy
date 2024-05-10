using Microsoft.AspNetCore.Identity;

namespace TalentAcademy.Domain.Entities.Identitiy
{
    public class AppRole : IdentityRole<Guid>
    {
        public List<AppUser> AppUsers { get; set; } = new();
    }
}
