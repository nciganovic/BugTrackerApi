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
    public class TicketPriorityConfiguration : IEntityTypeConfiguration<TicketPriority>
    {
        public void Configure(EntityTypeBuilder<TicketPriority> builder)
        {
            builder.Property(tp => tp.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(tp => tp.Name).IsUnique();

            builder.Property(tp => tp.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
