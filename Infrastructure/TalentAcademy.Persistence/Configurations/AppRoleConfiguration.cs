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
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            AppRole adminRole = new AppRole()
            {
                Id = new Guid(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            builder.HasData(adminRole);
        }
    }
}
