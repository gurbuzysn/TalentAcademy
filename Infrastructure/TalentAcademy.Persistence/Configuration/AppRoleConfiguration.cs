using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Persistence.Configuration
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            AppRole appRole = new()
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                NormalizedName = nameof(AppRole.Name).ToUpper()
            };

            builder.HasData(appRole);
        }
    }
}
