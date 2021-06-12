using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(au => au.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(au => au.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(au => au.Email)
                .IsRequired();

            builder.Property(au => au.Password)
                .IsRequired();

            builder.Property(au => au.Salt)
                .IsRequired();

            builder.HasIndex(au => au.Email).IsUnique();

            builder.Property(au => au.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Role)
                .WithMany(r => r.ApplicationUsers)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
