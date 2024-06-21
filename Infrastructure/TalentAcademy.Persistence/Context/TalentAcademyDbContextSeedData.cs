using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TalentAcademy.Application.Constants;
using TalentAcademy.Domain.Entities.Identitiy;
using TalentAcademy.Domain.Enums;

namespace TalentAcademy.Persistence.Context
{
    public static class TalentAcademyDbContextSeedData
    {
        public static async Task SeedAsync(TalentAcademyDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await context.Database.MigrateAsync();

            if (await context.Users.AnyAsync() && await context.Roles.AnyAsync())
                return;

            await roleManager.CreateAsync(new IdentityRole() { Name = AuthorizationConstant.Roles.ADMIN });
            await roleManager.CreateAsync(new IdentityRole() { Name = AuthorizationConstant.Roles.TRAINER });
            await roleManager.CreateAsync(new IdentityRole() { Name = AuthorizationConstant.Roles.STUDENT });

            var admin2 = new Admin();


            var admin = new Admin()
            {
                FirstName = AuthorizationConstant.ADMIN_FIRSTNAME,
                LastName = AuthorizationConstant.ADMIN_LASTNAME,
                UserName = AuthorizationConstant.ADMIN_USERNAME,
                NormalizedUserName = AuthorizationConstant.ADMIN_USERNAME.ToUpper(),
                Email = AuthorizationConstant.ADMIN_USERNAME,
                NormalizedEmail = AuthorizationConstant.ADMIN_USERNAME.ToUpper(),
                Gender = Gender.Erkek,
                DateOfBirth = new DateTime(1993, 02, 25),
                CreatedDate = DateTime.UtcNow,
                PhoneNumber = AuthorizationConstant.ADMIN_PHONE
            };

            await userManager.CreateAsync(admin, AuthorizationConstant.ADMIN_PASSWORD);
            await userManager.AddToRoleAsync(admin, AuthorizationConstant.Roles.ADMIN);

            var trainer = new Trainer()
            {
                FirstName = AuthorizationConstant.TRAINER_FIRSTNAME,
                LastName = AuthorizationConstant.TRAINER_LASTNAME,
                UserName = AuthorizationConstant.TRAINER_USERNAME,
                NormalizedUserName = AuthorizationConstant.TRAINER_USERNAME.ToUpper(),
                Email = AuthorizationConstant.TRAINER_USERNAME,
                NormalizedEmail = AuthorizationConstant.TRAINER_USERNAME.ToUpper(),
                Gender = Gender.Erkek,
                DateOfBirth = new DateTime(1973, 04, 10),
                CreatedDate = DateTime.UtcNow,
                PhoneNumber = AuthorizationConstant.TRAINER_PHONE
            };

            await userManager.CreateAsync(trainer, AuthorizationConstant.TRAINER_PASSWORD);
            await userManager.AddToRoleAsync(trainer, AuthorizationConstant.Roles.TRAINER);


            var student = new Student()
            {
                FirstName = AuthorizationConstant.STUDENT_FIRSTNAME,
                LastName = AuthorizationConstant.STUDENT_LASTNAME,
                UserName = AuthorizationConstant.STUDENT_USERNAME,
                NormalizedUserName = AuthorizationConstant.STUDENT_USERNAME.ToUpper(),
                Email = AuthorizationConstant.STUDENT_USERNAME,
                NormalizedEmail = AuthorizationConstant.STUDENT_USERNAME.ToUpper(),
                Gender = Gender.Erkek,
                DateOfBirth = new DateTime(2022, 08, 22),
                CreatedDate = DateTime.UtcNow,
                PhoneNumber = AuthorizationConstant.STUDENT_PHONE
            };

            await userManager.CreateAsync(student, AuthorizationConstant.STUDENT_PASSWORD);
            await userManager.AddToRoleAsync(student, AuthorizationConstant.Roles.STUDENT);
        }
    }
}
