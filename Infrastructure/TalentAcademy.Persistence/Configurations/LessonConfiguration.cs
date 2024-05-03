using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Persistence.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(l => l.Name).IsRequired().HasMaxLength(200);
            builder.Property(l => l.VideoUri).IsRequired();
        }
    }
}
