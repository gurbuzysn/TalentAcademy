using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TalentAcademy.Domain.Entities;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Persistence.Context
{
    public class TalentAcademyDbContext : IdentityDbContext
    {
        public TalentAcademyDbContext(DbContextOptions<TalentAcademyDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
