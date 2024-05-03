using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Image).IsRequired(false);
            builder.HasMany(s => s.StudentCourses).WithOne(sc => sc.Student).HasForeignKey(sc => sc.StundetId);
        }
    }
}
