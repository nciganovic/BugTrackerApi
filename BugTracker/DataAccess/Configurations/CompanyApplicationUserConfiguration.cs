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
    public class CompanyApplicationUserConfiguration : IEntityTypeConfiguration<CompanyApplicationUser>
    {
        public void Configure(EntityTypeBuilder<CompanyApplicationUser> builder)
        {
            builder.HasKey(x => new { x.CompanyId, x.ApplicationUserId });

            builder.HasOne(cau => cau.Company)
                .WithMany(c => c.CompanyApplicaitonUsers)
                .HasForeignKey(cau => cau.CompanyId);

            builder.HasOne(cau => cau.ApplicationUser)
                .WithMany(au => au.CompanyApplicaitonUsers)
                .HasForeignKey(cau => cau.ApplicationUserId);

            builder.HasOne(cau => cau.Role)
                .WithMany(r => r.CompanyApplicationUsers)
                .HasForeignKey(cau => cau.RoleId);
        }
    }
}
