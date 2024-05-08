using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Constants;
using TalentAcademy.Domain.Entities.Identitiy;
using TalentAcademy.Domain.Enums;

namespace TalentAcademy.Persistence.Context
{
    public static class TalentAcademyDbContextSeedData
    {
        public static async void SeedAsync(TalentAcademyDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await context.Users.AnyAsync() && await context.Roles.AnyAsync())
                return;


            var admin = new AppUser()
            {
                Id = Guid.NewGuid(),
                FirstName = AuthorizationConstant.ADMIN_FIRSTNAME,
                LastName = AuthorizationConstant.ADMIN_LASTNAME,
                UserName = AuthorizationConstant.ADMIN_USERNAME,
                NormalizedUserName = AuthorizationConstant.ADMIN_USERNAME.ToUpper(),
                Email = AuthorizationConstant.ADMIN_USERNAME,
                NormalizedEmail = AuthorizationConstant.ADMIN_USERNAME.ToUpper(),
                Gender = Gender.Erkek,
                DateOfBirth = new DateTime(1993, 02, 25),
                CreatedDate = DateTime.UtcNow
            };

            await userManager.CreateAsync(admin, AuthorizationConstant.ADMIN_PASSWORD);

            await roleManager.CreateAsync(new AppRole()
            {
                Id = Guid.NewGuid(),
                Name = AuthorizationConstant.Roles.ADMINISTRATOR,
                NormalizedName = AuthorizationConstant.Roles.ADMINISTRATOR.ToUpper()
            });

            await roleManager.CreateAsync(new AppRole()
            {
                Id = Guid.NewGuid(),
                Name = AuthorizationConstant.Roles.STUDENT,
                NormalizedName = AuthorizationConstant.Roles.STUDENT.ToUpper()
            });

            await userManager.AddToRoleAsync(admin, AuthorizationConstant.Roles.ADMINISTRATOR);
        }
    }
}
