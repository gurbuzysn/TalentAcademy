using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Domain.Entities;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Persistence.Context
{
    public class TalentAcademyDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public TalentAcademyDbContext(DbContextOptions<TalentAcademyDbContext> options) : base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}



    }
}
