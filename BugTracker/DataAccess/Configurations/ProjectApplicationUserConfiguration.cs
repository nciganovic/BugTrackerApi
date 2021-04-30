using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ProjectApplicationUserConfiguration : IEntityTypeConfiguration<ProjectApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ProjectApplicationUser> builder)
        {
            builder.HasKey(x => new { x.ProjectId, x.ApplicationUserId });

            builder.HasOne(pau => pau.Project)
                .WithMany(p => p.ProjectApplicationUsers)
                .HasForeignKey(pau => pau.ProjectId);

            builder.HasOne(pau => pau.ApplicationUser)
                .WithMany(au => au.ProjectApplicaitonUsers)
                .HasForeignKey(pau => pau.ApplicationUserId);
        }
    }
}
