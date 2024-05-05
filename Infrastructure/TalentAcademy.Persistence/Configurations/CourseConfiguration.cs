using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(c => c.Topics).WithOne(t => t.Course).HasForeignKey(t => t.CourseId);
        }
    }
}
