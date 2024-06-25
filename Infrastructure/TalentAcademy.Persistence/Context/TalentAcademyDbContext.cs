using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TalentAcademy.Domain.Entities;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Persistence.Context
{
    public class TalentAcademyDbContext : IdentityDbContext<AppUser>
    {
        public TalentAcademyDbContext(DbContextOptions<TalentAcademyDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Admin>().ToTable("Admins");
            builder.Entity<Trainer>().ToTable("Trainers");
            builder.Entity<Student>().ToTable("Students");
        }
    }
}
