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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasMany(r => r.RoleUserCases)
                .WithOne(uc => uc.Role)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(r => r.Name).IsUnique();

            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
